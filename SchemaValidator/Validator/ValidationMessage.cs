namespace Rootmap.SchemaValidator.Validator
{
  public class ValidationMessage
  {
    public enum Type
    {
      Warning,
      Error
    }

    public string Message { get; set; }
    public Type Severity { get; set; }
  }
}
