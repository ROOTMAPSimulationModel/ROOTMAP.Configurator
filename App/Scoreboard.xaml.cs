using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Scoreboard.xaml
  /// </summary>
  public partial class Scoreboard : BaseCodeBehind, IRemovable
  {
    private readonly Rootmap.Configurator.Schema.Scoreboards.Scoreboard _dataModel;
    public Scoreboard(Rootmap.Configurator.Schema.Scoreboards.Scoreboard dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new ScoreboardViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
