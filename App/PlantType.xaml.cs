using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.PlantTypes;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for PlantType.xaml
  /// </summary>
  public partial class PlantType : BaseCodeBehind, IRemovable
  {
    private readonly PlantTypesPlanttype _dataModel;
    public PlantType(Rootmap.Configurator.Schema.PlantTypes.PlantTypesPlanttype dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new PlantTypeViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
