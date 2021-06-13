using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.SharedAttributes;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for SharedAttribute.xaml
  /// </summary>
  public partial class SharedAttribute : BaseCodeBehind, IRemovable
  {
    private readonly SharedAttributesAttribute _dataModel;
    public SharedAttribute(SharedAttributesAttribute dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new SharedAttributeViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
