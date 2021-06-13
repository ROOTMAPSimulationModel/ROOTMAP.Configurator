using System;
using System.Xml;
using Rootmap.IO;

namespace Rootmap.SchemaValidator.Validator
{
  public class SchemaValidationObserver : IObserver<ValidationMessage>
  {
    public bool Verbose { get; private set; } = false;
    public bool ReportWarnings { get; private set; } = false;

    private int _errorCount = 0;
    private int _warningCount = 0;
    private readonly IOutput _console;

    public SchemaValidationObserver(bool reportWarnings, bool verbose, IOutput console)
    {
      ReportWarnings = reportWarnings;
      Verbose = verbose;
      _console = console;
    }

    public void OnCompleted(string path)
    {
      var clean = _errorCount == 0 && _warningCount == 0;
      var errorReport = $"with {_errorCount} error(s)";
      var warningReport = $", {_warningCount} warning(s).";
      var resultSummary = clean
          ? "successfully."
          : errorReport + (ReportWarnings ? warningReport : ".");
      if (Verbose || _errorCount > 0 || (_warningCount > 0 && ReportWarnings))
      {
        _console.WriteLine($"Validation of {Environment.NewLine}{path}{Environment.NewLine}completed {resultSummary}");
        _console.WriteLine("------------------------------------------------------------");
      }
      _errorCount = 0;
      _warningCount = 0;
    }

    public void OnError(Exception error)
    {
      var xmlException = error as XmlException;
      if (xmlException != null)
      {
        _console.WriteLine($"Error in {xmlException.SourceUri?.Replace("file:///", string.Empty)}");
      }
      _console.WriteLine($"{error.Message}{Environment.NewLine}");
    }

    public void OnNext(ValidationMessage value)
    {
      switch (value.Severity)
      {
        case ValidationMessage.Type.Error:
          _errorCount++;
          _console.WriteLine(value.Message);
          break;
        case ValidationMessage.Type.Warning:
          _warningCount++;
          if (ReportWarnings)
          {
            _console.WriteLine(value.Message);
          }
          break;
      }
    }

    public void OnCompleted()
    {
      OnCompleted(string.Empty);
    }
  }
}
