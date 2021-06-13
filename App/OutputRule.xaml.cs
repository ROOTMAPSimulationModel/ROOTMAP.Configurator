using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.OutputRules;
using System;
using System.Linq;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for OutputRule.xaml
  /// </summary>
  public partial class OutputRule : BaseCodeBehind, IRemovable
  {
    private readonly Rootmap.Configurator.Schema.OutputRules.OutputRule _dataModel;
    public OutputRule(Rootmap.Configurator.Schema.OutputRules.OutputRule dataModel, BaseViewModel viewModel = null)
    {
      Loaded += OutputRule_Loaded;
      _dataModel = dataModel;
      ViewModel = viewModel ?? new OutputRuleViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    private void OutputRule_Loaded(object sender, System.Windows.RoutedEventArgs e) =>
      TimingTypeCombo.ItemsSource = Enum.GetValues(typeof(ItemChoiceType)).Cast<ItemChoiceType>();

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
