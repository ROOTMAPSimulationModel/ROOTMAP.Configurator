using Rootmap.Configurator.Schema.PostOffice;

namespace Rootmap.Configurator.ViewModels
{
  public class PostOfficeViewModel : BaseViewModel
  {
    private readonly PostOfficeConstructionPostoffice _dataModel;

    public PostOfficeViewModel(PostOfficeConstructionPostoffice dataModel)
    {
      _dataModel = dataModel;
      RaiseAllPropertiesChanged();
    }

    public string DefaultRuntime
    {
      get
      {
        return _dataModel.defaultruntime;
      }
      set
      {
        _dataModel.defaultruntime = value;
        RaisePropertyChanged();
      }
    }

    public string NextEnd
    {
      get
      {
        return _dataModel.next_end;
      }
      set
      {
        _dataModel.next_end = value;
        RaisePropertyChanged();
      }
    }

    public string NextStart
    {
      get
      {
        return _dataModel.next_start;
      }
      set
      {
        _dataModel.next_start = value;
        RaisePropertyChanged();
      }
    }

    public string Now
    {
      get
      {
        return _dataModel.now;
      }
      set
      {
        _dataModel.now = value;
        RaisePropertyChanged();
      }
    }

    public string Previous
    {
      get
      {
        return _dataModel.previous;
      }
      set
      {
        _dataModel.previous = value;
        RaisePropertyChanged();
      }
    }

    public uint RandomSeed
    {
      get
      {
        return _dataModel.random_seed;
      }
      set
      {
        _dataModel.random_seed = value;
        RaisePropertyChanged();
      }
    }
  }
}
