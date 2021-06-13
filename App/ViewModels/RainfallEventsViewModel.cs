using Rootmap.Configurator.Schema.RainfallEvents;
using System;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class RainfallEventsViewModel : BaseViewModel
  {
    private readonly RainfallEventsData _dataModel;
    private RainfallEventViewModel[] _rainfallEventViewModels;

    public RainfallEventsViewModel(RainfallEventsData dataModel)
    {
      _dataModel = dataModel;
      _rainfallEventViewModels = _dataModel
          .floatarray
          .Value
          .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
          .Where(x => !string.IsNullOrWhiteSpace(x))
          .Select(x => new RainfallEventViewModel(x))
          .ToArray();
      foreach (var vm in _rainfallEventViewModels)
      {
        vm.PropertyChanged += Vm_PropertyChanged;
      }
      RaiseAllPropertiesChanged();
    }

    private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) => UpdateFloatArray();

    private void UpdateFloatArray()
    {
      _dataModel.floatarray = new RainfallEventsDataFloatarray
      {
        name = _dataModel.floatarray.name,
        Value = string.Join(Environment.NewLine, _rainfallEventViewModels.Select(x => x.ToString()))
      };
      RaisePropertyChanged(nameof(RainfallEvents));
    }

    public string Name
    {
      get => _dataModel.floatarray.name;
      set
      {
        _dataModel.floatarray.name = value;
        RaisePropertyChanged();
      }
    }

    public RainfallEventViewModel[] RainfallEvents
    {
      get => _rainfallEventViewModels;
      set
      {
        _rainfallEventViewModels = value;
        UpdateFloatArray();
      }
    }
  }
}
