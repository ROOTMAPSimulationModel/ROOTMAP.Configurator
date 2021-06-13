using Rootmap.Configurator.Schema.Windows;
using System;

namespace Rootmap.Configurator.ViewModels
{
  public class TableWindowViewModel : WindowViewModel
  {
    private readonly Schema.Windows.Table _dataModel;
    public TableWindowViewModel(Visualisation dataModel)
        : base(dataModel)
    {
      _dataModel = dataModel.Item as Schema.Windows.Table;
      if (_dataModel == null)
      {
        throw new ArgumentException($"Window Visualisation {dataModel.Item} is not a Table.");
      }
      RaiseAllPropertiesChanged();
    }

    public string CharacteristicName
    {
      get
      {
        return _dataModel.characteristic_name;
      }
      set
      {
        _dataModel.characteristic_name = value;
        RaisePropertyChanged();
      }
    }

    public int LayerNumber
    {
      get
      {
        return _dataModel.layer_number;
      }
      set
      {
        _dataModel.layer_number = value;
        RaisePropertyChanged();
      }
    }

    public string ProcessName
    {
      get
      {
        return _dataModel.process_name;
      }
      set
      {
        _dataModel.process_name = value;
        RaisePropertyChanged();
      }
    }

    public string Stratum
    {
      get
      {
        return _dataModel.stratum;
      }
      set
      {
        _dataModel.stratum = value;
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
  }
}
