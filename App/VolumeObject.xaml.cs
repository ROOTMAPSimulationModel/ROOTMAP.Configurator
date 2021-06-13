using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.VolumeObjects;
using System;
using System.Linq;
using System.ComponentModel;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for VolumeObject.xaml
  /// </summary>
  public partial class VolumeObject : BaseCodeBehind, IRemovable
  {
    private readonly Rootmap.Configurator.Schema.VolumeObjects.VolumeObject _dataModel;
    private readonly VolumeObjectViewModel _specificViewModel;
    public VolumeObject(Rootmap.Configurator.Schema.VolumeObjects.VolumeObject dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      _specificViewModel = ((VolumeObjectViewModel)viewModel) ?? new VolumeObjectViewModel(dataModel);
      ViewModel = _specificViewModel;
      _specificViewModel.PropertyChanged += vmPropertyChanged;
      Init();
      InitializeComponent();
      Loaded += VolumeObject_Loaded;
    }

    private void vmPropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateVisibility();

    private void UpdateVisibility()
    {
      var isCylinder = _specificViewModel.Type == VolumeObjectClass_name.BoundingCylinder;

      originPanel.Visibility = isCylinder
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Collapsed;
      radiusPanel.Visibility = isCylinder
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Collapsed;
      depthPanel.Visibility = isCylinder
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Collapsed;

      leftFrontTopPanel.Visibility = !isCylinder
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Collapsed;
      rightBackBottomPanel.Visibility = !isCylinder
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Collapsed;
    }

    private void VolumeObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      TypeCombo.ItemsSource = Enum.GetValues(typeof(VolumeObjectClass_name)).Cast<VolumeObjectClass_name>();
      AlgorithmCombo.ItemsSource = Enum.GetValues(typeof(VolumeObjectRoot_penetration_probabilityProbability_calculation_algorithm)).Cast<VolumeObjectRoot_penetration_probabilityProbability_calculation_algorithm>();
      UpdateVisibility();
    }

    protected override void OnPropertyChanged() => UpdateVisibility();

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
