using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.Windows;
using System;
using System.Linq;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Window.xaml
  /// </summary>
  public partial class Table : BaseCodeBehind, IRemovable
  {
    private readonly Visualisation _dataModel;
    public Table(Visualisation dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new TableWindowViewModel(dataModel);
      Init();
      InitializeComponent();
      Loaded += Table_Loaded;
    }

    private void Table_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      ViewDirectionCombo.ItemsSource = Enum.GetValues(typeof(ViewDirection)).Cast<ViewDirection>();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
