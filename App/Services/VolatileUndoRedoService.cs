using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NLog;
using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator.Services
{
  /// <summary>
  /// Simple implementation of IUndoRedoService. Does not persist anything to disk; works only within a single session of the application.
  /// </summary>
  public class VolatileUndoRedoService : IUndoRedoService
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();
    private readonly Stack<Change> _history;
    private int _pointer;
    private readonly Dictionary<FieldIdentifier, Tuple<BaseViewModel, object>> _accessedViewModels;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public VolatileUndoRedoService()
    {
      _history = new Stack<Change>();
      _accessedViewModels = new Dictionary<FieldIdentifier, Tuple<BaseViewModel, object>>();
    }

    public bool CanUndo => _history.Any() && _pointer < _history.Count;
    public bool CanRedo => _history.Any() && _pointer > 0;

    public void Undo()
    {
      if (!CanUndo)
      {
        throw new InvalidOperationException("Nothing to undo.");
      }
      var c = _history.ElementAt(_pointer);
      logger.Info($"Undoing change. Field: {c.FieldId.FieldName}. Old: {c.OldValue}. New: {c.NewValue}");
      _pointer++;
      var vm = _accessedViewModels[c.FieldId];
      vm.Item1.SetValue(c.FieldId.FieldName, c.OldValue);
      PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
    }

    public void Redo()
    {
      if (!CanRedo)
      {
        throw new InvalidOperationException("Nothing to redo.");
      }
      _pointer--;
      var c = _history.ElementAt(_pointer);
      logger.Info($"Redoing change. Field: {c.FieldId.FieldName}. Old: {c.OldValue}. New: {c.NewValue}");
      var vm = _accessedViewModels[c.FieldId];
      vm.Item1.SetValue(c.FieldId.FieldName, c.NewValue);
      PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
    }

    public void RegisterViewModelAccess(FieldIdentifier fieldIdentifier, BaseViewModel vm)
    {
      if (!_accessedViewModels.ContainsKey(fieldIdentifier))
      {
        _accessedViewModels[fieldIdentifier] = Tuple.Create(vm, vm.GetCurrentValue(fieldIdentifier.FieldName));
      }
    }

    public void Record(IsolatedChange change)
    {
      ClearRedoStack();
      var prevValue = _history
        .FirstOrDefault(x => x.FieldId.Equals(change.FieldId))?.NewValue;
      var c = new Change(change, prevValue ?? _accessedViewModels[change.FieldId].Item2);
      if (c.NewValue?.Equals(c.OldValue) != true)
      {
        _history.Push(c);
        _pointer = 0;
        PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
      }
    }

    private void ClearRedoStack()
    {
      while (_pointer > 0)
      {
        var c = _history.Pop();
        logger.Info($"Discarded the following redoable change because a new user-driven change was detected. Field: {c.FieldId.FieldName}. Old: {c.OldValue}. New: {c.NewValue}");
        _pointer--;
      }
    }

    private void LogUndoRedoStackState()
    {
      foreach (var v in _history)
      {
        logger.Info($"Field: {v.FieldId.FieldName}. Old: {v.OldValue}. New: {v.NewValue}");
      }
    }

    public string CurrentConfigurationName { get; set; }

    public string PreviousConfigurationName => CanUndo ? _history.ElementAt(_pointer).FieldId.ConfigurationName : CurrentConfigurationName;

    public string NextConfigurationName => CanRedo ? _history.ElementAt(_pointer - 1).FieldId.ConfigurationName : CurrentConfigurationName;
  }
}
