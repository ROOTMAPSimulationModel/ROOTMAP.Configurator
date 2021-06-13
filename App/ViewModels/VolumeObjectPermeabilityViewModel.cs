using Rootmap.Configurator.Schema.VolumeObjects;

namespace Rootmap.Configurator.ViewModels
{
  public class VolumeObjectPermeabilityViewModel : BaseViewModel
  {
    private readonly VolumeObjectPermeability _dataModel;

    public VolumeObjectPermeabilityViewModel(VolumeObjectPermeability dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public decimal Bottom
    {
      get { return _dataModel.bottom; }
      set
      {
        _dataModel.bottom = value;
        RaisePropertyChanged();
      }
    }

    public decimal Sides
    {
      get { return _dataModel.sides; }
      set
      {
        _dataModel.sides = value;
        RaisePropertyChanged();
      }
    }

    public decimal Top
    {
      get { return _dataModel.top; }
      set
      {
        _dataModel.top = value;
        RaisePropertyChanged();
      }
    }

    public VolumeObjectPermeability DataModel => _dataModel;
  }
}
