using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.ScoreboardData;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for ScoreboardData.xaml
  /// </summary>
  public partial class ScoreboardData : BaseCodeBehind, IRemovable
  {
    private readonly ScoreboardDataScoreboarddata _dataModel;
    public ScoreboardData(ScoreboardDataScoreboarddata dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new ScoreboardDataViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
