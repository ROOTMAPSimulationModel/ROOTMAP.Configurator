namespace Rootmap.Configurator.Services
{
  public class Change : IsolatedChange
  {
    public object OldValue { get; }

    public Change(IsolatedChange originalChange, object oldValue)
      : base(originalChange)
    {
      OldValue = oldValue;
    }
  }
}
