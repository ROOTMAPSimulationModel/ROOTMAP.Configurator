using System.ComponentModel;

namespace Rootmap.Configurator.ViewModels
{
  public class OutputRuleViewModel : BaseViewModel
  {
    private readonly Rootmap.Configurator.Schema.OutputRules.OutputRule _dataModel;
    private WhenViewModel _whenViewModel;

    public OutputRuleViewModel(Rootmap.Configurator.Schema.OutputRules.OutputRule dataModel)
    {
      _dataModel = dataModel;
      WhenViewModel = new WhenViewModel(_dataModel.when);
      WhenViewModel.PropertyChanged += _whenViewModel_PropertyChanged;
      RaiseAllPropertiesChanged();
    }

    protected void _whenViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => RaisePropertyChanged(nameof(WhenViewModel));

    public string Characteristic
    {
      get { return _dataModel.characteristic; }
      set
      {
        _dataModel.characteristic = value;
        RaisePropertyChanged();
      }
    }

    public string Name
    {
      get { return _dataModel.filename; }
      set
      {
        _dataModel.filename = value;
        RaisePropertyChanged();
      }
    }

    public Rootmap.Configurator.Schema.OutputRules.OutputRuleReopen Reopen
    {
      get { return _dataModel.reopen; }
      set
      {
        _dataModel.reopen = value;
        RaisePropertyChanged();
      }
    }

    public string Source
    {
      get { return _dataModel.source; }
      set
      {
        _dataModel.source = value;
        RaisePropertyChanged();
      }
    }

    public string Specification1
    {
      get { return _dataModel.specification1; }
      set
      {
        _dataModel.specification1 = value;
        RaisePropertyChanged();
      }
    }

    public string Specification2
    {
      get { return _dataModel.specification2; }
      set
      {
        _dataModel.specification2 = value;
        RaisePropertyChanged();
      }
    }

    public string Stratum
    {
      get { return _dataModel.stratum; }
      set
      {
        _dataModel.stratum = value;
        RaisePropertyChanged();
      }
    }

    public string Type
    {
      get { return _dataModel.type; }
      set
      {
        _dataModel.type = value;
        RaisePropertyChanged();
      }
    }

    public WhenViewModel WhenViewModel
    {
      get { return _whenViewModel; }
      set
      {
        _whenViewModel = value;
        _dataModel.when = _whenViewModel.DataModel;
        RaisePropertyChanged();
      }
    }
  }
}
