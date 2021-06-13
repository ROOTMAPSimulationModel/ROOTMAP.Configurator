using Rootmap.Configurator.Schema.SharedAttributes;

namespace Rootmap.Configurator.ViewModels
{
  public class SharedAttributeViewModel : BaseViewModel
  {
    private readonly SharedAttributesAttribute _dataModel;
    private SharedAttributeCharacteristicViewModel _characteristicViewModel;
    private SharedAttributeDefaultsViewModel _defaults;

    public SharedAttributeViewModel(SharedAttributesAttribute dataModel)
    {
      _dataModel = dataModel;
      _characteristicViewModel = new SharedAttributeCharacteristicViewModel(_dataModel.characteristic_descriptor);
      DefaultsViewModel = new SharedAttributeDefaultsViewModel(_dataModel.defaults ?? new Defaults());
      RaiseAllPropertiesChanged();
    }

    public SharedAttributeCharacteristicViewModel CharacteristicViewModel
    {
      get
      {
        return _characteristicViewModel;
      }
      set
      {
        _characteristicViewModel = value;
        _dataModel.characteristic_descriptor = value.DataModel;
        RaisePropertyChanged();
      }
    }

    public SharedAttributeDefaultsViewModel DefaultsViewModel
    {
      get
      {
        return _defaults;
      }
      set
      {
        _defaults = value;
        _dataModel.defaults = value.DataModel;
        RaisePropertyChanged();
      }
    }

    public string Owner
    {
      get
      {
        return _dataModel.owner;
      }
      set
      {
        _dataModel.owner = value;
        RaisePropertyChanged();
      }
    }

    public string Storage
    {
      get
      {
        return _dataModel.storage;
      }
      set
      {
        _dataModel.storage = value;
        RaisePropertyChanged();
      }
    }

    public string Values
    {
      get
      {
        return _dataModel.values;
      }
      set
      {
        _dataModel.values = value;
        RaisePropertyChanged();
      }
    }

    public string Variations
    {
      get
      {
        return _dataModel.variations;
      }
      set
      {
        _dataModel.variations = value;
        RaisePropertyChanged();
      }
    }
  }
}
