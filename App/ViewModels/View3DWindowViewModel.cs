using Rootmap.Configurator.Schema.Windows;
using System;

namespace Rootmap.Configurator.ViewModels
{
  public class View3DWindowViewModel : WindowViewModel
  {
    private readonly Schema.Windows.View3D _dataModel;
    private CoordinateViewModel _viewPositionVm;

    public View3DWindowViewModel(Visualisation dataModel)
        : base(dataModel)
    {
      _dataModel = dataModel.Item as Schema.Windows.View3D;
      if (_dataModel == null)
      {
        throw new ArgumentException($"Window Visualisation {dataModel.Item} is not a View3D.");
      }
      _viewPositionVm = new CoordinateViewModel(_dataModel.view_position);
      _viewPositionVm.PropertyChanged += ViewPositionVm_PropertyChanged;
      RaiseAllPropertiesChanged();
    }

    public decimal BaseRootBlue
    {
      get
      {
        return _dataModel.base_root_blue;
      }
      set
      {
        _dataModel.base_root_blue = value;
        RaisePropertyChanged();
      }
    }

    public decimal BaseRootGreen
    {
      get
      {
        return _dataModel.base_root_green;
      }
      set
      {
        _dataModel.base_root_green = value;
        RaisePropertyChanged();
      }
    }

    public decimal BaseRootRed
    {
      get
      {
        return _dataModel.base_root_red;
      }
      set
      {
        _dataModel.base_root_red = value;
        RaisePropertyChanged();
      }
    }

    public bool Boundaries
    {
      get
      {
        return _dataModel.boundaries;
      }
      set
      {
        _dataModel.boundaries = value;
        RaisePropertyChanged();
      }
    }

    public bool BoxColours
    {
      get
      {
        return _dataModel.box_colours;
      }
      set
      {
        _dataModel.box_colours = value;
        RaisePropertyChanged();
      }
    }

    public bool Boxes
    {
      get
      {
        return _dataModel.boxes;
      }
      set
      {
        _dataModel.boxes = value;
        RaisePropertyChanged();
      }
    }

    public bool HighContrastRootColour
    {
      get
      {
        return _dataModel.high_contrast_root_colour;
      }
      set
      {
        _dataModel.high_contrast_root_colour = value;
        RaisePropertyChanged();
      }
    }

    public string Processes
    {
      get
      {
        return _dataModel.processes;
      }
      set
      {
        _dataModel.processes = value;
        RaisePropertyChanged();
      }
    }

    public View3DQuality Quality
    {
      get
      {
        return _dataModel.quality;
      }
      set
      {
        _dataModel.quality = value;
        RaisePropertyChanged();
      }
    }

    public bool RootColourByBranchOrder
    {
      get
      {
        return _dataModel.root_colour_by_branch_order;
      }
      set
      {
        _dataModel.root_colour_by_branch_order = value;
        RaisePropertyChanged();
      }
    }

    public decimal RootRadiusMultiplier
    {
      get
      {
        return _dataModel.root_radius_multiplier;
      }
      set
      {
        _dataModel.root_radius_multiplier = value;
        RaisePropertyChanged();
      }
    }

    public decimal Scale
    {
      get
      {
        return _dataModel.scale;
      }
      set
      {
        _dataModel.scale = value;
        RaisePropertyChanged();
      }
    }

    public string Scoreboards
    {
      get
      {
        return _dataModel.scoreboards;
      }
      set
      {
        _dataModel.scoreboards = value;
        RaisePropertyChanged();
      }
    }

    public CoordinateViewModel ViewPosition
    {
      get => _viewPositionVm;
      set
      {
        _viewPositionVm = value;
        _dataModel.view_position = value.ToString();
        RaisePropertyChanged();
      }
    }

    private void ViewPositionVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      _dataModel.view_position = _viewPositionVm.ToString();
      RaisePropertyChanged();
    }
  }
}
