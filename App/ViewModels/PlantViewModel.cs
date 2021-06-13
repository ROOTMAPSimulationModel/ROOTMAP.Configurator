using Rootmap.Configurator.Schema.Plants;
using System.ComponentModel;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class PlantViewModel : BaseViewModel
  {
    private readonly PlantsPlant _dataModel;
    private CoordinateViewModel _originVm;
    private CoordinateViewModel _seedLocationVm;
    private AxisViewModel[] _nodalAxisViewModels;
    private AxisViewModel[] _seminalAxisViewModels;

    public PlantViewModel(PlantsPlant dataModel)
    {
      _dataModel = dataModel;
      _originVm = new CoordinateViewModel(_dataModel.origin);
      _originVm.PropertyChanged += OriginVm_PropertyChanged;
      _seedLocationVm = new CoordinateViewModel(_dataModel.seed_location);
      _seedLocationVm.PropertyChanged += SeedLocationVm_PropertyChanged;
      NodalAxes = _dataModel.nodal_axis
          .Select(ToAxisViewModel)
          .ToArray();
      SeminalAxes = _dataModel.seminal_axis
          .Select(ToAxisViewModel)
          .ToArray();
      RaiseAllPropertiesChanged();
    }

    protected void _axisViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => RaisePropertyChanged(nameof(AxisViewModel));

    private AxisViewModel ToAxisViewModel(Axis axis)
    {
      var vm = new AxisViewModel(axis);
      vm.PropertyChanged += _axisViewModel_PropertyChanged;
      return vm;
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

    public CoordinateViewModel Origin
    {
      get => _originVm;
      set
      {
        _originVm = value;
        _dataModel.origin = Origin.ToString();
        RaisePropertyChanged();
      }
    }

    private void OriginVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) => _dataModel.origin = Origin.ToString();

    public decimal SeedingTime
    {
      get { return _dataModel.seeding_time; }
      set
      {
        _dataModel.seeding_time = value;
        RaisePropertyChanged();
      }
    }

    public CoordinateViewModel SeedLocation
    {
      get => _seedLocationVm;
      set
      {
        _seedLocationVm = value;
        _dataModel.seed_location = SeedLocation.ToString();
        RaisePropertyChanged();
      }
    }

    private void SeedLocationVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) => _dataModel.seed_location = SeedLocation.ToString();

    public string Type
    {
      get { return _dataModel.type; }
      set
      {
        _dataModel.type = value;
        RaisePropertyChanged();
      }
    }

    public AxisViewModel[] NodalAxes
    {
      get => _nodalAxisViewModels;
      set
      {
        _nodalAxisViewModels = value;
        _dataModel.nodal_axis = value
            .Select(x => x.DataModel)
            .ToArray();
        RaisePropertyChanged();
      }
    }

    public AxisViewModel[] SeminalAxes
    {
      get => _seminalAxisViewModels;
      set
      {
        _seminalAxisViewModels = value;
        _dataModel.seminal_axis = value
            .Select(x => x.DataModel)
            .ToArray();
        RaisePropertyChanged();
      }
    }
  }
}
