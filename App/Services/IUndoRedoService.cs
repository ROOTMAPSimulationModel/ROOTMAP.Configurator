using System.ComponentModel;
using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator.Services
{
  public interface IUndoRedoService : INotifyPropertyChanged
  {
    bool CanUndo { get; }
    bool CanRedo { get; }
    string CurrentConfigurationName { get; set; }

    /// <summary>
    /// Undoes the most recent non-undone change and records the fact that it has been undone.
    /// </summary>
    void Undo();

    /// <summary>
    /// Redoes the most recently undone change and records the fact that it has been redone.
    /// </summary>
    void Redo();

    /// <summary>
    /// Registers a view model that has been accessed via a field. Calls back to the BaseViewModel to look up the current ("initial") value of the field in question.
    /// </summary>
    void RegisterViewModelAccess(FieldIdentifier fieldIdentifier, BaseViewModel vm);

    /// <summary>
    /// Records a change made by the end user (where the previous value of the field is not known). Wipes any redoable changes that may exist.
    /// </summary>
    void Record(IsolatedChange c);

    string PreviousConfigurationName { get; }

    string NextConfigurationName { get; }
  }
}
