using Rootmap.Configurator.Schema.Plants;

namespace Rootmap.Configurator.ViewModels
{
  public class AxisViewModel : BaseViewModel
  {
    public AxisViewModel(Axis dataModel)
    {
      _dataModel = dataModel;
      StartLag = _dataModel.start_lag;
      Probability = _dataModel.probability;
    }

    public decimal StartLag
    {
      get => _dataModel.start_lag;
      set
      {
        _dataModel.start_lag = value;
        RaisePropertyChanged();
      }
    }

    private readonly Axis _dataModel;

    public decimal Probability
    {
      get => _dataModel.probability;
      set
      {
        _dataModel.probability = value;
        RaisePropertyChanged();
      }
    }

    public Axis DataModel => _dataModel;
  }
}
