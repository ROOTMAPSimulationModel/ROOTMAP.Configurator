using Rootmap.Configurator.Services;
using Rootmap.Configurator.ViewModels;
using Microsoft.Win32;
using Rootmap.Configurator.Schema;
using Rootmap.Configurator.Schema.Main;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NLog;
using System.Windows.Data;
using Rootmap.IO;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();

    private const string MainFilename = "rootmap.xml";
    private readonly ILoader _loader = SimpleIoC.Container.Resolve<ILoader>();
    private readonly IPathProvider _pathProvider = SimpleIoC.Container.Resolve<IPathProvider>();
    private readonly IPersister _persister = SimpleIoC.Container.Resolve<IPersister>();
    private readonly IUndoRedoService _undoRedoService = SimpleIoC.Container.Resolve<IUndoRedoService>();

    private MainViewModel _mainViewModel;
    private dynamic _selectedDataModel;
    private static string initialOutputPath;

    public static string InitialOutputPath
    {
      get => initialOutputPath;
      set
      {
        var temp = Path.GetFullPath(value ?? throw new ArgumentNullException(nameof(InitialOutputPath)));
        if (!Directory.Exists(temp))
        {
          throw new ArgumentException($"Path {temp} does not exist!", nameof(InitialOutputPath));
        }
        initialOutputPath = temp;
      }
    }

    public MainWindow()
    {
      // Set up a binding to keep the undo/redo menu items properly en/disabled
      _undoRedoService.PropertyChanged += (obj, e) =>
      {
        if (UndoMenuItem != null)
        {
          BindingOperations.GetBindingExpression(UndoMenuItem, MenuItem.IsEnabledProperty).UpdateTarget();
        }
        if (RedoMenuItem != null)
        {
          BindingOperations.GetBindingExpression(RedoMenuItem, MenuItem.IsEnabledProperty).UpdateTarget();
        }
      };
      if (string.IsNullOrWhiteSpace(InitialOutputPath))
      {
        var openedDir = OpenConfigurationViaDialog();
        try
        {
          InitialOutputPath = openedDir;
        }
        catch (ArgumentException)
        {
          MessageBox.Show($"Could not open ROOTMAP configuration in directory {(string.IsNullOrWhiteSpace(openedDir) ? "[blank]" : openedDir)}");
        }
      }
      Initialise(InitialOutputPath ?? ".");
    }

    private void Initialise(string dir)
    {
      try
      {
        _mainViewModel = OpenViewModel(dir);
        DataContext = _mainViewModel;
        InitializeComponent();
        Title = _mainViewModel.TitleWithOutputPath;
        if (string.IsNullOrEmpty(_pathProvider.GuiRootmap))
        {
          RunRootmapMenuItem.IsEnabled = false;
          RunRootmapMenuItem.ToolTip = "Could not locate an installation of GUI ROOTMAP.";
        }
        // TODO figure out if we want to be able to launch CLI ROOTMAP from the config app too.
        // (probably yes, but having a pair of almost-identical menu items to do it is not ideal.)
        // if (string.IsNullOrEmpty(_pathProvider.CliRootmap)) {
        //   RunRootmapMenuItem.IsEnabled = false;
        //   RunRootmapMenuItem.ToolTip = "Could not locate an installation of CLI ROOTMAP.";
        // }
        Container.Visibility = Visibility.Visible;
      }
      catch (Exception e)
      {
#if DEBUG
        MessageBox.Show(e.Message + e.StackTrace);
#else
        MessageBox.Show($"Could not load configuration from {dir}. {e.Message}.");
#endif
      }
    }

    private MainViewModel OpenViewModel(string dir, int callCount = 0)
    {
      try
      {
        var dataModel = _loader.OpenOrCreate(
            Path.Combine(dir, MainFilename),
            "Main",
            "Main");
        var vm = new MainViewModel(dataModel, dir);
        WriteFullConfigurationToDisk(vm, true);
        return vm;
      }
      catch (RootmapConfigurationException e)
      {
        if (callCount > 0)
        {
          throw new RootmapConfigurationException($"Could not convert files at {dir} into a usable ROOTMAP configuration.", e);
        }
        BackupConfiguration(dir);
        ConvertConfiguration(dir);
        return OpenViewModel(dir, callCount + 1);
      }
    }

    private void BackupConfiguration(string sourceDir)
    {
      try
      {
        var parentDir = Path.GetDirectoryName(sourceDir);
        var sd = Path.GetRelativePath(parentDir, sourceDir);
        DirectoryCopy(sourceDir, Path.Combine(parentDir, $"{sd}-backup-{DateTime.Now:yyyyMMddThhmm}"), true);
      }
      catch (Exception e)
      {
        logger.Error($"Could not take a backup copy of ROOTMAP configuration at {sourceDir}: {e.Message}");
      }
    }

    // Copied from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      // Get the subdirectories for the specified directory.
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
            "Source directory does not exist or could not be found: "
            + sourceDirName);
      }

      DirectoryInfo[] dirs = dir.GetDirectories();

      // If the destination directory doesn't exist, create it.
      Directory.CreateDirectory(destDirName);

      // Get the files in the directory and copy them to the new location.
      FileInfo[] files = dir.GetFiles();
      foreach (FileInfo file in files)
      {
        string tempPath = Path.Combine(destDirName, file.Name);
        file.CopyTo(tempPath, false);
      }

      // If copying subdirectories, copy them and their contents to new location.
      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string tempPath = Path.Combine(destDirName, subdir.Name);
          DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
        }
      }
    }

    private void ConvertConfiguration(string dir)
    {
      try
      {
        logger.Info($"Attempting to update old configuration...");

        var outcomes = Rootmap.ConfigurationImporter.ConfigurationTransformer.transformAllFiles(dir);

        foreach (var o in outcomes)
        {
          if (!o.Item2)
          {
            logger.Info($"FAILURE: {o.Item1}");
          }
          else
          {
            logger.Info($"SUCCESS: {o.Item1}");
          }
        }
        logger.Info($"Updated ROOTMAP configuration files in {dir}.");
      }
      catch (Exception e)
      {
        logger.Error($"Error: {e.Message}");
      }
    }

    /// <summary>
    /// Serialise an initial copy of each referenced configuration file to disk,
    /// skipping any which already exist.
    /// </summary>
    private void WriteFullConfigurationToDisk(MainViewModel vm, bool performInlineConversion = false)
    {
      foreach (var obj in vm
          .MainConfigurations
          .Select(x => new { Model = OpenDataModel(vm, x), Location = x.location })
          .Concat(new[] { new { Model = new CreateStandardMain().Create(_loader), Location = MainFilename } }))
      {
        _persister.Persist(obj.Model, vm.OutputPath, obj.Location, false);
      }
    }

    // Returns true if selection was changed, otherwise false.
    private bool SelectConfigurationElementByName(string name)
    {
      var currentlySelectedItem = ConfigurationsGrid.SelectedItem;
      if ((currentlySelectedItem as MainConfiguration)?.name != name)
      {
        var selectedItem = ConfigurationsGrid.Items
          .Cast<object>()
          .Select(x => x as MainConfiguration)
          .Where(x => x != null)
          .Single(x => x.name == name);
        ConfigurationsGrid.SelectedItem = selectedItem;
        return true;
      }
      return false;
    }

    private void SelectConfigurationElement(object selectedItem)
    {
      if (selectedItem is MainConfiguration selectedConfigObj)
      {
        SelectConfigObj(selectedConfigObj);
      }
    }

    private void SelectConfigObj(MainConfiguration selectedConfigObj)
    {
      _selectedDataModel = OpenDataModel(_mainViewModel, selectedConfigObj);
      _undoRedoService.CurrentConfigurationName = selectedConfigObj.name;
      Detail.Children.Clear();
      foreach (var collectionModel in _selectedDataModel.GetCollectionEntities())
      {
        var d = new Detail(collectionModel, _mainViewModel.OutputPath, selectedConfigObj.location, selectedConfigObj.owner);
        d.PropertyChanged += Detail_PropertyChanged;
        Detail.Children.Add(d);
      }
    }

    private void PersistSelectedDataModel(string filename)
    {
      if (_selectedDataModel != null)
      {
        _persister.Persist(_selectedDataModel, _mainViewModel.OutputPath, filename, true);
      }
    }

    private dynamic OpenDataModel(MainViewModel vm, MainConfiguration config)
    {
      var openedConfiguration = _loader.OpenOrCreate(
          Path.Combine(vm.OutputPath, config.location),
          SchemaNames.GetSchemaName(config.name),
          config.name);
      return openedConfiguration;
    }

    private async Task LaunchGuiRootmap()
    {
      try
      {
        var guiRootmapPath = _pathProvider.GuiRootmap;
        var processRunner = new ProcessRunner(guiRootmapPath);
        Container.IsEnabled = false;
        Container.ToolTip = "Configuration is locked for editing while open in ROOTMAP.";
        var error = await processRunner.Run($"\"{_mainViewModel.OutputPath}\"");
        if (!string.IsNullOrEmpty(error))
        {
          throw new ApplicationException($"Error attempting to run ROOTMAP: {error}");
        }
      }
      catch (Exception)
      {
        // TODO Handle gracefully
        throw;
      }
      finally
      {
        Container.IsEnabled = true;
        Container.ToolTip = string.Empty;
      }
    }

    private void OpenConfiguration(string path)
    {
      // Close the currently open configuration and open the next.
      CloseConfiguration();
      Initialise(path);
    }

    private void CloseConfiguration()
    {
      Title = "ROOTMAP Configuration App";
      _mainViewModel = null;
      Detail?.Children.Clear();
      if (Container != null)
      {
        Container.Visibility = Visibility.Hidden;
      }
    }

    // Copied wholesale from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories.
    private static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs, string fileExtensionFilter = "*")
    {
      // Get the subdirectories for the specified directory.
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
            "Source directory does not exist or could not be found: "
            + sourceDirName);
      }

      DirectoryInfo[] dirs = dir.GetDirectories();
      // If the destination directory doesn't exist, create it.
      if (!Directory.Exists(destDirName))
      {
        Directory.CreateDirectory(destDirName);
      }

      // Get the files in the directory and copy them to the new location.
      FileInfo[] files = dir.GetFiles(fileExtensionFilter);
      foreach (FileInfo file in files)
      {
        string tempPath = Path.Combine(destDirName, file.Name);
        file.CopyTo(tempPath, true);
      }

      // If copying subdirectories, copy them and their contents to new location.
      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string tempPath = Path.Combine(destDirName, subdir.Name);
          CopyDirectory(subdir.FullName, tempPath, copySubDirs, fileExtensionFilter);
        }
      }
    }

    private string OpenConfigurationViaDialog()
    {
      var openFileDialog = new OpenFileDialog
      {
        DefaultExt = ".xml",
        InitialDirectory = _mainViewModel?.OutputPath,
        FileName = MainFilename,
        Filter = "XML files (*.xml)|*.xml"
      };
      var directory = string.Empty;
      if (openFileDialog.ShowDialog() == true)
      {
        directory = Path.GetDirectoryName(openFileDialog.FileName);
        OpenConfiguration(directory);
      }
      return directory;
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) => SelectConfigurationElement(((DataGrid)sender).SelectedItem);
    private void Detail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) => PersistSelectedDataModel(e.PropertyName);

    private void HandleOpenCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => OpenConfigurationViaDialog();

    private void HandleSaveAsCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
      using (var dialog = new System.Windows.Forms.FolderBrowserDialog()
      {
        Description = "Select directory to save into",
        SelectedPath = _mainViewModel.OutputPath,
        ShowNewFolderButton = true
      })
      {
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
          try
          {
            CopyDirectory(_mainViewModel.OutputPath, dialog.SelectedPath, true, "*.xml");
            _mainViewModel.OutputPath = dialog.SelectedPath;
            Initialise(_mainViewModel.OutputPath);
          }
          catch (Exception)
          {
            throw;
          }
        }
      }
    }

    public bool CanUndo => _undoRedoService.CanUndo;
    public bool CanRedo => _undoRedoService.CanRedo;

    private void HandleCloseCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => CloseConfiguration();
    private void HandleExitCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => Application.Current.Shutdown();
    private async void HandleRunRootmapCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => await LaunchGuiRootmap();
    private void HandleUndoCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
      if (CanUndo)
      {
        SelectConfigurationElementByName(_undoRedoService.PreviousConfigurationName);
        _undoRedoService.Undo();
      }
    }
    private void HandleRedoCommand(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
      if (CanRedo)
      {
        SelectConfigurationElementByName(_undoRedoService.NextConfigurationName);
        _undoRedoService.Redo();
      }
    }
  }
}
