using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for PostOffice.xaml
  /// </summary>
  public partial class PostOffice : BaseCodeBehind
  {
    public PostOffice(Rootmap.Configurator.Schema.PostOffice.PostOfficeConstructionPostoffice dataModel, BaseViewModel viewModel = null)
    {
      ViewModel = viewModel ?? new PostOfficeViewModel(dataModel);
      Init();
      InitializeComponent();
    }
  }
}
