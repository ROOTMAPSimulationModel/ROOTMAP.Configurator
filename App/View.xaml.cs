using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.Windows;
using System;
using System.Linq;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Window.xaml
  /// </summary>
  public partial class View : BaseCodeBehind, IRemovable
  {
    private readonly Visualisation _dataModel;
    public View(Visualisation dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new ViewWindowViewModel(dataModel);
      Init();
      InitializeComponent();
      Loaded += View_Loaded;
    }

    private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      ViewDirectionCombo.ItemsSource = Enum.GetValues(typeof(ViewDirection)).Cast<ViewDirection>();
      var v = (_dataModel.Item as Rootmap.Configurator.Schema.Windows.View);
      //Cyan = new CharacteristicColourInfo(v.characteristics.cyan);
      //Magenta = new CharacteristicColourInfo(v.characteristics.magenta);
      //Yellow = new CharacteristicColourInfo(v.characteristics.yellow);
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
