using System.Collections.Generic;
using System.ComponentModel;
using Rootmap.Configurator.Services;

namespace Rootmap.Configurator.ViewModels
{
  /// <summary>
  /// Read-only view of console messages produced by other components of the application.
  /// </summary>
  public class ConsoleViewModel : INotifyPropertyChanged
  {
    private readonly ConsoleOutputDataModel _dataModel = SimpleIoC.Container.Resolve<ConsoleOutputDataModel>();

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public ConsoleViewModel() => _dataModel.PropertyChanged += OnDataModelChanged;

    private void OnDataModelChanged(object sender, PropertyChangedEventArgs e) => PropertyChanged(this, new PropertyChangedEventArgs(nameof(Lines)));

    public IList<string> Lines
    {
      get => _dataModel.Lines;
    }
  }
}
