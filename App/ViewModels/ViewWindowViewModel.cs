using Rootmap.Configurator.Schema.Windows;
using System;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class ViewWindowViewModel : WindowViewModel
  {
    private readonly Schema.Windows.View _dataModel;
    private WindowCharacteristicColourInfoViewModel[] _characteristicColourInfoViewModels;

    public ViewWindowViewModel(Visualisation dataModel)
        : base(dataModel)
    {
      _dataModel = (dataModel.Item as Schema.Windows.View) ?? throw new ArgumentException($"Window Visualisation {dataModel.Item} is not a View.");
      CharacteristicColourInfoViewModels = new WindowCharacteristicColourInfoViewModel[]
      {
        new WindowCharacteristicColourInfoViewModel(_dataModel.characteristics.cyan),
        new WindowCharacteristicColourInfoViewModel(_dataModel.characteristics.magenta),
        new WindowCharacteristicColourInfoViewModel(_dataModel.characteristics.yellow)
      };
      RaiseAllPropertiesChanged();
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

    public Characteristics Characteristics
    {
      get
      {
        return _dataModel.characteristics;
      }
      set
      {
        _dataModel.characteristics = value;
        RaisePropertyChanged();
      }
    }

    public WindowCharacteristicColourInfoViewModel[] CharacteristicColourInfoViewModels
    {
      get { return _characteristicColourInfoViewModels; }
      set
      {
        _characteristicColourInfoViewModels = value;
        var models = _characteristicColourInfoViewModels
            .Select(x => x.DataModel);
        _dataModel.characteristics = new Characteristics
        {
          cyan = models.First(),
          magenta = models.Skip(1).First(),
          yellow = models.Skip(2).First()
        };
      }
    }

    public string ReferenceIndex
    {
      get
      {
        return _dataModel.reference_index;
      }
      set
      {
        _dataModel.reference_index = value;
        RaisePropertyChanged();
      }
    }

    public bool Repeat
    {
      get
      {
        return _dataModel.repeat;
      }
      set
      {
        _dataModel.repeat = value;
        RaisePropertyChanged();
      }
    }

    public ViewDirection ViewDirection
    {
      get
      {
        return _dataModel.view_direction;
      }
      set
      {
        _dataModel.view_direction = value;
        RaisePropertyChanged();
      }
    }

    public decimal ZoomRatio
    {
      get
      {
        return _dataModel.zoom_ratio;
      }
      set
      {
        _dataModel.zoom_ratio = value;
        RaisePropertyChanged();
      }
    }

    public bool Wrap
    {
      get
      {
        return _dataModel.wrap;
      }
      set
      {
        _dataModel.wrap = value;
        RaisePropertyChanged();
      }
    }
  }
}
