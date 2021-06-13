using Rootmap.Configurator.Schema.PlantTypes;

namespace Rootmap.Configurator.ViewModels
{
  public class PlantTypeViewModel : BaseViewModel
  {
    private readonly PlantTypesPlanttype _dataModel;

    public PlantTypeViewModel(PlantTypesPlanttype dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public string Name
    {
      get { return _dataModel.name; }
      set
      {
        _dataModel.name = value;
        RaisePropertyChanged();
      }
    }

    public decimal FirstSeminalProbability
    {
      get { return _dataModel.first_seminal_probability; }
      set
      {
        _dataModel.first_seminal_probability = value;
        RaisePropertyChanged();
      }
    }

    public decimal GerminationLag
    {
      get { return _dataModel.germination_lag; }
      set
      {
        _dataModel.germination_lag = value;
        RaisePropertyChanged();
      }
    }

    public decimal InitialSeminalDeflection
    {
      get { return _dataModel.initial_seminal_deflection; }
      set
      {
        _dataModel.initial_seminal_deflection = value;
        RaisePropertyChanged();
      }
    }

    public decimal RootsToFoliageRatio
    {
      get { return _dataModel.roots_to_foliage_ratio; }
      set
      {
        _dataModel.roots_to_foliage_ratio = value;
        RaisePropertyChanged();
      }
    }

    public decimal StructureToPhotosynthesizeRatio
    {
      get { return _dataModel.structure_to_photosynthesize_ratio; }
      set
      {
        _dataModel.structure_to_photosynthesize_ratio = value;
        RaisePropertyChanged();
      }
    }

    public decimal TemperatureOfZeroGrowth
    {
      get { return _dataModel.temperature_of_zero_growth; }
      set
      {
        _dataModel.temperature_of_zero_growth = value;
        RaisePropertyChanged();
      }
    }

    public decimal VegetateToReproduceRatio
    {
      get { return _dataModel.vegetate_to_reproduce_ratio; }
      set
      {
        _dataModel.vegetate_to_reproduce_ratio = value;
        RaisePropertyChanged();
      }
    }
  }
}
