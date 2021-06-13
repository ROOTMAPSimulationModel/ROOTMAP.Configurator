using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.Windows;
using System;
using System.Linq;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Window.xaml
  /// </summary>
  public partial class View3D : BaseCodeBehind, IRemovable
  {
    private readonly Visualisation _dataModel;
    public View3D(Visualisation dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new View3DWindowViewModel(dataModel);
      Init();
      InitializeComponent();
      Loaded += View3D_Loaded;
    }

    private void View3D_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      QualityCombo.ItemsSource = Enum.GetValues(typeof(View3DQuality)).Cast<View3DQuality>();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
