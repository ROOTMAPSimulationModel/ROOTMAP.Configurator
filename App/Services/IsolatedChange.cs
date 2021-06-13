using System;

namespace Rootmap.Configurator.Services
{
  public class IsolatedChange
  {
    public FieldIdentifier FieldId { get; protected set; }
    public object NewValue { get; protected set; }
    public DateTimeOffset Timestamp { get; protected set; }

    public IsolatedChange(FieldIdentifier fieldId, object newValue)
    {
      FieldId = fieldId;
      NewValue = newValue;
      Timestamp = DateTimeOffset.Now;
    }

    // For use by derived class <code>Change</code>.
    protected IsolatedChange()
    { }

    protected IsolatedChange(IsolatedChange originalChange)
      : this(originalChange.FieldId, originalChange.NewValue)
    {
      Timestamp = originalChange.Timestamp;
    }
  }
}
