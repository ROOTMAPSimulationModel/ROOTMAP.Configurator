using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rootmap.Configurator.Services;

namespace Rootmap.Configurator.ViewModels
{
  public abstract class BaseViewModel : INotifyPropertyChanged
  {
    private readonly IUndoRedoService _undoRedoService = SimpleIoC.Container.Resolve<IUndoRedoService>();
    public readonly Guid Id = Guid.NewGuid();
    public bool UndoingOrRedoing = false;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public object GetCurrentValue(string propertyName) => GetType().GetProperty(propertyName).GetValue(this);
    public void SetValue(string propertyName, object value)
    {
      try
      {
        UndoingOrRedoing = true;
        GetType().GetProperty(propertyName).SetValue(this, value);
      }
      finally
      {
        UndoingOrRedoing = false;
      }
    }

    protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (!UndoingOrRedoing)
      {
        var fId = new FieldIdentifier(_undoRedoService.CurrentConfigurationName, this.Id, propertyName);
        _undoRedoService.RegisterViewModelAccess(fId, this);
        _undoRedoService.Record(new IsolatedChange(fId, GetCurrentValue(propertyName)));
      }
      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void RaiseAllPropertiesChanged()
    {
      foreach (var prop in this.GetType().GetProperties())
      {
        _undoRedoService.RegisterViewModelAccess(new FieldIdentifier(_undoRedoService.CurrentConfigurationName, this.Id, prop.Name), this);
      }
      PropertyChanged(this, null);
    }
  }
}
