using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class ScoreboardViewModel : BaseViewModel
  {
    private readonly Schema.Scoreboards.Scoreboard _dataModel;
    private readonly IList<BoundaryArrayViewModel> _boundaryArrayViewModels;

    public ScoreboardViewModel(Schema.Scoreboards.Scoreboard dataModel)
    {
      _dataModel = dataModel;
      _boundaryArrayViewModels = _dataModel
          .boundaryarray
          .Select(ToBoundaryArrayViewModel)
          .ToList();
      RaiseAllPropertiesChanged();
    }

    protected void _boundaryArrayViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => RaisePropertyChanged(nameof(BoundaryArrayViewModel));

    private BoundaryArrayViewModel ToBoundaryArrayViewModel(Schema.Scoreboards.BoundaryArray ba)
    {
      var vm = new BoundaryArrayViewModel(ba);
      vm.PropertyChanged += _boundaryArrayViewModel_PropertyChanged;
      return vm;
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

    public int Stratum
    {
      get { return _dataModel.stratum; }
      set
      {
        _dataModel.stratum = value;
        RaisePropertyChanged();
      }
    }

    public IList<BoundaryArrayViewModel> BoundaryArrays
    {
      get { return _boundaryArrayViewModels; }
    }
  }
}
