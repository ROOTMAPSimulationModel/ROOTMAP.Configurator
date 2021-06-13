using System.Windows;
using Rootmap.Configurator.Services;
using Rootmap.Configurator.Schema;
using System.Linq;
using System;
using System.IO;
using NLog;
using System.Windows.Controls;
using Rootmap.IO;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();

    private string DefaultConfigDir => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ROOTMAP", "v0.1.6", "Configurations", "default"); // TODO need to get the correct version!

    SimpleIoC IoC = SimpleIoC.Container;
    protected override void OnStartup(StartupEventArgs e)
    {
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
      var configDirectoryArg = e.Args
          .FirstOrDefault();
      if (!string.IsNullOrWhiteSpace(configDirectoryArg))
      {
        // If config directory has been passed in, it *has to* be correct.
        // (i.e. will throw if it does not exist.)
        Rootmap.Configurator.MainWindow.InitialOutputPath = configDirectoryArg;
      }
      else
      {
        try
        {
          // If we're just trying for the default config directory,
          // allow it to fail if nonexistent,
          Rootmap.Configurator.MainWindow.InitialOutputPath = DefaultConfigDir;
        }
        catch (ArgumentException)
        {
          // and finally, default to the current directory. If all else fails.
          // UPDATE: No longer want to do this. Want to leave this path null and trigger the file open dialog instead.
          // Rootmap.Configurator.MainWindow.InitialOutputPath = ".";
        }
      }
      IoC.Register<ILoader, XmlLoader>();
      IoC.Register<IPersister, XmlSerialiser>();
      IoC.Register<IPathProvider, RegistryPathProvider>();
      var c = new ConsoleOutputDataModel();
      IoC.RegisterSingleton<IOutput, ConsoleOutputDataModel>(c); // Register as a singleton, because there's "only one console".
      IoC.RegisterSingleton<ConsoleOutputDataModel, ConsoleOutputDataModel>(c); // Also register it as itself, so its viewmodel can find it.
      IoC.RegisterSingleton<IUndoRedoService, VolatileUndoRedoService>();
      IoC.RegisterSingleton<IViewModelCache, VolatileViewModelStore>();

      EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
      base.OnStartup(e);
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      if (e.IsTerminating)
      {
        logger.Fatal(e.ExceptionObject as Exception);
      }
      else
      {
        logger.Error(e.ExceptionObject as Exception);
      }
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      TextBox tb = sender as TextBox;
      tb?.Focus();
      tb?.SelectAll();
    }
  }
}
