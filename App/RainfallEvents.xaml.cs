using Rootmap.Configurator.ViewModels;
using Rootmap.Configurator.Schema.RainfallEvents;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for RainfallEvents.xaml
  /// </summary>
  public partial class RainfallEvents : BaseCodeBehind
  {
    private readonly RainfallEventsViewModel _specificViewModel;
    public RainfallEvents(RainfallEventsData dataModel, BaseViewModel viewModel = null)
    {
      _specificViewModel = ((RainfallEventsViewModel)viewModel) ?? new RainfallEventsViewModel(dataModel);
      ViewModel = _specificViewModel;
      Init();
      InitializeComponent();
    }

    private void AddNewLineButton_Clicked(object sender, RoutedEventArgs e)
    {
      var newLine = new RainfallEventViewModel("0.0,0.0,0.0,0.0,0.0,0.0");
      _specificViewModel.RainfallEvents = _specificViewModel.RainfallEvents
          .ToList()
          .Concat(new List<RainfallEventViewModel> { newLine })
          .ToArray();
    }

    private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
    {
      _specificViewModel.RainfallEvents = _specificViewModel.RainfallEvents
          .Where(x => !x.MarkedForDeletion)
          .ToArray();
    }
  }
}
