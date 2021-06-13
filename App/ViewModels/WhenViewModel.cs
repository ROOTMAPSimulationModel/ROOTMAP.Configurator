using Rootmap.Configurator.Schema.OutputRules;

namespace Rootmap.Configurator.ViewModels
{
  // This will need a switch between the various When modes.
  public class WhenViewModel : BaseViewModel
  {
    private readonly When _dataModel;

    public WhenViewModel(When dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public int Count
    {
      get { return _dataModel.count; }
      set
      {
        _dataModel.count = value;
        RaisePropertyChanged();
      }
    }

    public string InitialTime
    {
      get { return _dataModel.initialtime; }
      set
      {
        _dataModel.initialtime = value;
        RaisePropertyChanged();
      }
    }

    public string Item
    {
      get { return _dataModel.Item; }
      set
      {
        _dataModel.Item = value;
        RaisePropertyChanged();
      }
    }

    public ItemChoiceType ItemElementName
    {
      get { return _dataModel.ItemElementName; }
      set
      {
        _dataModel.ItemElementName = value;
        RaisePropertyChanged();
      }
    }

    public When DataModel => _dataModel;
  }
}
