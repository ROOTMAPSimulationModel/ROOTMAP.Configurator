using System;

namespace Rootmap.Configurator.ViewModels
{
  public class WindowCharacteristicColourInfoViewModel : BaseViewModel, ICharacteristicColourInfoViewModel
  {
    private readonly Schema.Windows.CharacteristicColourInfo _dataModel;
    public WindowCharacteristicColourInfoViewModel(Schema.Windows.CharacteristicColourInfo dataModel)
    {
      _dataModel = dataModel ?? throw new ArgumentNullException(nameof(dataModel));
    }

    public int ColourMax
    {
      get => _dataModel.colour_max;
      set
      {
        _dataModel.colour_max = value;
        RaisePropertyChanged();
      }
    }

    public int ColourMin
    {
      get => _dataModel.colour_min;
      set
      {
        _dataModel.colour_min = value;
        RaisePropertyChanged();
      }
    }

    public decimal CharacteristicMax
    {
      get => _dataModel.characteristic_max;
      set
      {
        _dataModel.characteristic_max = value;
        RaisePropertyChanged();
      }
    }

    public decimal CharacteristicMin
    {
      get => _dataModel.characteristic_min;
      set
      {
        _dataModel.characteristic_min = value;
        RaisePropertyChanged();
      }
    }

    public string CharacteristicName
    {
      get => _dataModel.characteristic_name;
      set
      {
        _dataModel.characteristic_name = value;
        RaisePropertyChanged();
      }
    }

    public string ProcessName
    {
      get => _dataModel.process_name;
      set
      {
        _dataModel.process_name = value;
        RaisePropertyChanged();
      }
    }

    public Schema.Windows.CharacteristicColourInfo DataModel => _dataModel;
  }
}
