using Rootmap.Configurator.Schema.Windows;

namespace Rootmap.Configurator.ViewModels
{
  public abstract class WindowViewModel : BaseViewModel
  {
    private readonly Visualisation _dataModel;

    public WindowViewModel(Visualisation dataModel) => _dataModel = dataModel;

    public ViewOwner Owner
    {
      get { return _dataModel.owner; }
      set
      {
        _dataModel.owner = value;
        RaisePropertyChanged();
      }
    }
  }
}
