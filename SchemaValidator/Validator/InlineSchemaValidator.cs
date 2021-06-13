using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Rootmap.SchemaValidator.Validator
{
  public class InlineSchemaValidator : ISchemaValidator
  {
    private readonly XmlReaderSettings _settings;
    private SchemaValidationObserver _validationObserver;

    private ResultSummary _results = new ResultSummary();

    public InlineSchemaValidator()
    {
      var schemaFileNames = new List<string>
      {
        "Main",
        "OutputRules",
        "Plants",
        "PlantTypes",
        "PostOffice",
        "Processes",
        "RainfallEvents",
        "RendererAndWindows",
        "ScoreboardData",
        "Scoreboards",
        "SharedAttributes",
        "VolumeObjects"
      };

      XmlSchema common;
      using (var reader = XmlReader.Create("https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Common.xsd"))
      {
        common = XmlSchema.Read(reader, (_, __) => { });
      }
      XmlSchemaSet set = new XmlSchemaSet
      {
        XmlResolver = new XmlUrlResolver()
      };

      foreach (var sfn in schemaFileNames)
      {
        var schemaName = sfn == "RendererAndWindows" ? "View" : sfn;

        XmlSchema schema;
        using (var reader = XmlReader.Create($"https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/{sfn}.xsd"))
        {
          schema = XmlSchema.Read(reader, (_, __) => { });
        }
        schema.TargetNamespace = $"https://example.org/ROOTMAP/{schemaName}Schema";

        XmlSchemaInclude include = new XmlSchemaInclude
        {
          Schema = common
        };
        schema.Includes.Add(include);
        set.Add(schema);
      }

      set.Compile();

      _settings = new XmlReaderSettings()
      {
        ValidationType = ValidationType.Schema,
        Schemas = set
      };
      _settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      _settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
      _settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      _settings.ValidationEventHandler += ValidationCallBack;
    }

    public void Subscribe(SchemaValidationObserver validationObserver) => _validationObserver = validationObserver;

    public ResultSummary ValidateFile(string xmlFilePath)
    {
      _results = new ResultSummary();
      for (var wait = 250; wait <= 2000; wait *= 2)
      {
        try
        {
          using (XmlReader reader = XmlReader.Create(xmlFilePath, _settings))
          {
            try
            {
              while (reader.Read()) ;
            }
            catch (Exception e)
            {
              _results.ErrorCount++;
              _validationObserver?.OnError(e);
            }
          }
          _validationObserver?.OnCompleted(xmlFilePath);
          return _results;
        }
        catch (IOException)
        {
          if (wait > 1000) throw;
          Task.Delay(wait).Wait();
        }
      }
      throw new Exception("Coding error. This should never happen.");
    }

    private void ValidationCallBack(object sender, ValidationEventArgs args)
    {
      var message = string.Empty;
      var reader = sender as XmlReader;
      if (reader == null)
      {
        throw new ArgumentException("Validating object was not an XML reader?");
      }
      var messageType = "Error";
      var severity = ValidationMessage.Type.Error;
      var messageAddendum = string.Empty;
      if (args.Severity == XmlSeverityType.Warning)
      {
        severity = ValidationMessage.Type.Warning;
        messageType = "Warning";
        var fileNotFoundException = args.Exception?.InnerException as System.IO.FileNotFoundException;
        if (fileNotFoundException != null)
        {
          messageAddendum += $"{Environment.NewLine}Could not validate "
              + $"because no schema found at {fileNotFoundException.FileName}.";
        }
      }
      var type = sender.GetType();
      var lineNumberProp = type.GetProperty("LineNumber");
      var lineNumber = lineNumberProp?.GetValue(sender);
      var lineNumberString = lineNumber == null
          ? string.Empty
          : $"line {lineNumber}{Environment.NewLine}";
      message = $"{messageType} in {reader.BaseURI}{Environment.NewLine}"
          + $"{lineNumberString}{args.Message}{messageAddendum}{Environment.NewLine}";

      if (severity == ValidationMessage.Type.Error)
      {
        _results.ErrorCount++;
      }
      else
      {
        _results.WarningCount++;
      }
      _validationObserver?.OnNext(new ValidationMessage
      {
        Message = message,
        Severity = severity
      });
    }
  }
}
