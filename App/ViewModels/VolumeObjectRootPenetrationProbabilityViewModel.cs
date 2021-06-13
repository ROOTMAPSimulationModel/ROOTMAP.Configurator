using Rootmap.Configurator.Schema.VolumeObjects;

namespace Rootmap.Configurator.ViewModels
{
  public class VolumeObjectRootPenetrationProbabilityViewModel : BaseViewModel
  {
    private readonly VolumeObjectRoot_penetration_probability _dataModel;

    public VolumeObjectRootPenetrationProbabilityViewModel(VolumeObjectRoot_penetration_probability dataModel)
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

    public VolumeObjectRoot_penetration_probabilityProbability_calculation_algorithm ProbabilityCalculationAlgorithm
    {
      get { return _dataModel.probability_calculation_algorithm; }
      set
      {
        _dataModel.probability_calculation_algorithm = value;
        RaisePropertyChanged();
      }
    }

    public VolumeObjectRoot_penetration_probability DataModel => _dataModel;
  }
}
