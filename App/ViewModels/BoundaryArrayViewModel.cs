using Rootmap.Configurator.Schema.Scoreboards;

namespace Rootmap.Configurator.ViewModels
{
  public class BoundaryArrayViewModel : BaseViewModel
  {
    private readonly BoundaryArray _dataModel;

    public BoundaryArrayViewModel(BoundaryArray dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public Dimension Dimension
    {
      get { return _dataModel.dimension; }
      set
      {
        _dataModel.dimension = value;
        RaisePropertyChanged();
      }
    }

    public string PositionArray
    {
      get { return _dataModel.positionarray; }
      set
      {
        _dataModel.positionarray = value;
        RaisePropertyChanged();
      }
    }
  }
}
