using Rootmap.Configurator.Schema.SharedAttributes;

namespace Rootmap.Configurator.ViewModels
{
  public class SharedAttributeDefaultsViewModel : BaseViewModel
  {
    private readonly Defaults _dataModel;

    public SharedAttributeDefaultsViewModel(Defaults dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public string Values
    {
      get { return _dataModel.values; }
      set
      {
        _dataModel.values = value;
        RaisePropertyChanged();
      }
    }

    public string VariationName
    {
      get { return _dataModel.variation_name; }
      set
      {
        _dataModel.variation_name = value;
        RaisePropertyChanged();
      }
    }

    public Defaults DataModel => _dataModel;
  }
}
