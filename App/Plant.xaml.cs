using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.Plants;
using System.ComponentModel;
using System.Windows.Controls;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Plant.xaml
  /// </summary>
  public partial class Plant : BaseCodeBehind, IRemovable
  {
    private readonly PlantsPlant _dataModel;
    public Plant(Rootmap.Configurator.Schema.Plants.PlantsPlant dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new PlantViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    // A bit of a hack to stop the DataModel plumbing property from being rendered.
    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
      PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
      e.Column.Header = propertyDescriptor.DisplayName;
      if (propertyDescriptor.DisplayName == "DataModel")
      {
        e.Cancel = true;
      }
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
