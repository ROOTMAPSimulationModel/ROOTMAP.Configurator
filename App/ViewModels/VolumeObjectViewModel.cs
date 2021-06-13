using Rootmap.Configurator.Schema.VolumeObjects;

namespace Rootmap.Configurator.ViewModels
{
  public class VolumeObjectViewModel : BaseViewModel
  {
    private readonly Schema.VolumeObjects.VolumeObject _dataModel;
    private CoordinateViewModel _originVm;
    private CoordinateViewModel _leftFrontTopVm;
    private CoordinateViewModel _rightBackBottomVm;
    private VolumeObjectRootPenetrationProbabilityViewModel _rppViewModel;
    private VolumeObjectPermeabilityViewModel _permeabilityViewModel;

    public VolumeObjectViewModel(Schema.VolumeObjects.VolumeObject dataModel)
    {
      _dataModel = dataModel;
      _originVm = new CoordinateViewModel(_dataModel.origin);
      _originVm.PropertyChanged += OriginVm_PropertyChanged;
      _leftFrontTopVm = new CoordinateViewModel(_dataModel.leftfronttop);
      _leftFrontTopVm.PropertyChanged += LeftFrontTopVm_PropertyChanged;
      _rightBackBottomVm = new CoordinateViewModel(_dataModel.rightbackbottom);
      _rightBackBottomVm.PropertyChanged += RightBackBottomVm_PropertyChanged;
      RootPenetrationProbabilityViewModel = new VolumeObjectRootPenetrationProbabilityViewModel(_dataModel.root_penetration_probability);
      PermeabilityViewModel = new VolumeObjectPermeabilityViewModel(_dataModel.permeability);
      RaiseAllPropertiesChanged();
    }

    public CoordinateViewModel Origin
    {
      get => _originVm;
      set
      {
        _originVm = value;
        _dataModel.origin = value.ToString();
        RaisePropertyChanged();
      }
    }

    private void OriginVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      _dataModel.origin = _originVm.ToString();
      RaisePropertyChanged();
    }

    public CoordinateViewModel LeftFrontTop
    {
      get => _leftFrontTopVm;
      set
      {
        _leftFrontTopVm = value;
        _dataModel.leftfronttop = value.ToString();
        RaisePropertyChanged();
      }
    }

    private void LeftFrontTopVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      _dataModel.leftfronttop = _leftFrontTopVm.ToString();
      RaisePropertyChanged();
    }

    public CoordinateViewModel RightBackBottom
    {
      get => _leftFrontTopVm;
      set
      {
        _leftFrontTopVm = value;
        _dataModel.rightbackbottom = value.ToString();
        RaisePropertyChanged();
      }
    }

    private void RightBackBottomVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      _dataModel.rightbackbottom = _rightBackBottomVm.ToString();
      RaisePropertyChanged();
    }

    public VolumeObjectClass_name Type
    {
      get { return _dataModel.class_name; }
      set
      {
        _dataModel.class_name = value;
        RaisePropertyChanged();
      }
    }

    public decimal Depth
    {
      get { return _dataModel.depth; }
      set
      {
        _dataModel.depth = value;
        RaisePropertyChanged();
      }
    }

    public VolumeObjectPermeabilityViewModel PermeabilityViewModel
    {
      get => _permeabilityViewModel;
      set
      {
        _permeabilityViewModel = value;
        _dataModel.permeability = _permeabilityViewModel.DataModel;
        RaisePropertyChanged();
      }
    }

    public decimal Radius
    {
      get { return _dataModel.radius; }
      set
      {
        _dataModel.radius = value;
        RaisePropertyChanged();
      }
    }

    public VolumeObjectRootPenetrationProbabilityViewModel RootPenetrationProbabilityViewModel
    {
      get => _rppViewModel;
      set
      {
        _rppViewModel = value;
        _dataModel.root_penetration_probability = _rppViewModel.DataModel;
        RaisePropertyChanged();
      }
    }
  }
}
