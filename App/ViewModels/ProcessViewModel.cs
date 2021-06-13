using Rootmap.Configurator.Schema.Processes;
using System;
using System.ComponentModel;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class ProcessViewModel : BaseViewModel
  {
    private readonly ProcessesProcess _dataModel;
    private ProcessCharacteristicViewModel[] _characteristicViewModels;

    public ProcessViewModel(ProcessesProcess dataModel)
    {
      _dataModel = dataModel;
      if (_dataModel.characteristic == null)
      {
        _dataModel.characteristic = new Characteristic[] { };
      }
      CharacteristicViewModels = _dataModel
          .characteristic
          .Select(ToProcessCharacteristicViewModel)
          .ToArray();
      RaiseAllPropertiesChanged();
    }

    protected void _processCharacteristicViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => RaisePropertyChanged(nameof(ProcessCharacteristicViewModel));

    private ProcessCharacteristicViewModel ToProcessCharacteristicViewModel(Characteristic c)
    {
      var p = new ProcessCharacteristicViewModel(c);
      p.PropertyChanged += _processCharacteristicViewModel_PropertyChanged;
      return p;
    }

    public string Name
    {
      get { return _dataModel.name; }
      set
      {
        _dataModel.name = value;
        RaisePropertyChanged();
      }
    }

    public string ActivityType
    {
      get { return _dataModel.activitytype; }
      set
      {
        _dataModel.activitytype = value;
        RaisePropertyChanged();
      }
    }

    public Characteristic[] Characteristics
    {
      get { return _dataModel.characteristic; }
      set
      {
        _dataModel.characteristic = value;
        RaisePropertyChanged();
      }
    }

    public bool Override
    {
      get { return _dataModel.@override; }
      set
      {
        _dataModel.@override = value;
        RaisePropertyChanged();
      }
    }

    public string Scoreboard
    {
      get { return _dataModel.scoreboard; }
      set
      {
        _dataModel.scoreboard = value;
        RaisePropertyChanged();
      }
    }

    public ProcessCharacteristicViewModel[] CharacteristicViewModels
    {
      get => _characteristicViewModels;
      set
      {
        _characteristicViewModels = value;
        _dataModel.characteristic = _characteristicViewModels
            .Select(x => x.DataModel)
            .ToArray();
        RaisePropertyChanged();
      }
    }

    public void AddCharacteristicViewModel(ProcessCharacteristicViewModel vm = null)
    {
      vm = vm ?? new ProcessCharacteristicViewModel(new Characteristic());
      vm.PropertyChanged += _processCharacteristicViewModel_PropertyChanged;
      CharacteristicViewModels = CharacteristicViewModels
          .Concat(new ProcessCharacteristicViewModel[] { vm })
          .ToArray();
    }

    public void RemoveCharacteristicViewModel(ProcessCharacteristicViewModel vm)
    {
      CharacteristicViewModels = CharacteristicViewModels
          .Where(x => x != vm)
          .ToArray();
    }
  }
}
