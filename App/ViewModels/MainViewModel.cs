using Rootmap.Configurator.Services;
using Rootmap.Configurator.Schema;
using Rootmap.Configurator.Schema.Main;
using System;
using System.Linq;
using System.IO;

namespace Rootmap.Configurator.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    private rootmap _main;
    private ILoader _loader = SimpleIoC.Container.Resolve<ILoader>();
    private string _outputPath;

    public MainViewModel(rootmap main, string outputPath)
    {
      _main = main ?? throw new ArgumentNullException(nameof(main));
      OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
      Sort();
      RaiseAllPropertiesChanged();
    }

    public MainConfiguration[] MainConfigurations
    {
      get { return _main.configuration; }
      set
      {
        _main.configuration = value;
        Sort();
        RaisePropertyChanged();
      }
    }

    private void Sort()
    {
      _main.configuration = MainConfigurations
          .OrderBy(x => x.location)
          .ThenBy(x => x.type)
          .ThenBy(x => x.owner)
          .ThenBy(x => x.name)
          .ToArray();
    }

    public string OutputPath
    {
      get => _outputPath; set
      {
        _outputPath = Path.GetFullPath(value ?? throw new ArgumentNullException(nameof(OutputPath)));
        if (!Directory.Exists(_outputPath))
        {
          throw new ArgumentException($"Path {_outputPath} does not exist!", nameof(OutputPath));
        }
        RaisePropertyChanged();
      }
    }

    public string TitleWithOutputPath => string.IsNullOrWhiteSpace(OutputPath) ? "ROOTMAP Configuration App" : $"ROOTMAP Configuration App - editing {OutputPath}";
  }
}
