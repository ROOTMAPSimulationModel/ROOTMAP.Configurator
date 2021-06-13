using Rootmap.Configurator.Schema.Processes;

namespace Rootmap.Configurator.ViewModels
{
  public class ProcessCharacteristicViewModel : BaseViewModel
  {
    private readonly Characteristic _dataModel;

    public ProcessCharacteristicViewModel(Characteristic dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
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

    public double Maximum
    {
      get { return _dataModel.maximum; }
      set
      {
        _dataModel.maximum = value;
        RaisePropertyChanged();
      }
    }

    public double Minimum
    {
      get { return _dataModel.minimum; }
      set
      {
        _dataModel.minimum = value;
        RaisePropertyChanged();
      }
    }

    public bool SpecialPerBoxInfo
    {
      get { return _dataModel.specialperboxinfo; }
      set
      {
        _dataModel.specialperboxinfo = value;
        RaisePropertyChanged();
      }
    }

    public bool ToBeSaved
    {
      get { return _dataModel.tobesaved; }
      set
      {
        _dataModel.tobesaved = value;
        RaisePropertyChanged();
      }
    }

    public string Units
    {
      get { return _dataModel.units; }
      set
      {
        _dataModel.units = value;
        RaisePropertyChanged();
      }
    }

    public bool Visible
    {
      get { return _dataModel.visible; }
      set
      {
        _dataModel.visible = value;
        RaisePropertyChanged();
      }
    }

    public Characteristic DataModel => _dataModel;
  }
}
