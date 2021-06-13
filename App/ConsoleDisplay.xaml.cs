using Rootmap.Configurator.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;

namespace Rootmap.Configurator
{
  public partial class ConsoleDisplay : UserControl, INotifyPropertyChanged
  {
    public ConsoleDisplay()
    {
      ViewModel.PropertyChanged += _viewModel_PropertyChanged;
      InitializeComponent();
      DataContext = ViewModel;
    }

    public ConsoleViewModel ViewModel { get; } = new ConsoleViewModel();

    public event PropertyChangedEventHandler PropertyChanged = delegate { };
    protected void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => PropertyChanged(sender, e);
  }
}
