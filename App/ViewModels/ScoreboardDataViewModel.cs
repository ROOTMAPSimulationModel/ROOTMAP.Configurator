using Rootmap.Configurator.Schema.ScoreboardData;

namespace Rootmap.Configurator.ViewModels
{
  public class ScoreboardDataViewModel : BaseViewModel
  {
    private readonly ScoreboardDataScoreboarddata _dataModel;

    public ScoreboardDataViewModel(ScoreboardDataScoreboarddata dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public string Process
    {
      get
      {
        return _dataModel.process;
      }
      set
      {
        _dataModel.process = value;
        RaisePropertyChanged();
      }
    }

    public string Scheme
    {
      get
      {
        return _dataModel.scheme;
      }
      set
      {
        _dataModel.scheme = value;
        RaisePropertyChanged();
      }
    }

    public string Characteristic
    {
      get
      {
        return _dataModel.characteristic;
      }
      set
      {
        _dataModel.characteristic = value;
        RaisePropertyChanged();
      }
    }
  }
}
