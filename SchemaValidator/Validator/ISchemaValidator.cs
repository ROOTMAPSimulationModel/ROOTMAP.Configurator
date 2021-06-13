namespace Rootmap.SchemaValidator.Validator
{
  public interface ISchemaValidator
  {
    ResultSummary ValidateFile(string xmlFilePath);
    void Subscribe(SchemaValidationObserver validationObserver);
  }
}
