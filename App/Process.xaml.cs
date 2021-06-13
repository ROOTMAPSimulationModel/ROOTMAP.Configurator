using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.Processes;
using System.Windows.Controls;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Process.xaml
  /// </summary>
  public partial class Process : BaseCodeBehind
  {
    private readonly ProcessesProcess _dataModel;
    private readonly ProcessViewModel _specificViewModel;
    public Process(ProcessesProcess dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      _specificViewModel = ((ProcessViewModel)viewModel) ?? new ProcessViewModel(dataModel);
      ViewModel = _specificViewModel;
      Init();
      InitializeComponent();
    }

    private void DeleteCharacteristicDescriptor(object sender, System.Windows.RoutedEventArgs e) =>
        _specificViewModel.RemoveCharacteristicViewModel(((sender as Button)?.DataContext as ProcessCharacteristicViewModel));

    private void AddNewCharacteristicDescriptor(object sender, System.Windows.RoutedEventArgs e) =>
      _specificViewModel.AddCharacteristicViewModel();
  }
}
