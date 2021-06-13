using Rootmap.Configurator.Services;
using Rootmap.IO;
using Rootmap.SchemaValidator.Validator;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Rootmap.Configurator
{
  public class XmlSerialiser : IPersister
  {
    private IOutput _consoleDisplay;
    private InlineSchemaValidator _validator;

    private static readonly XmlWriterSettings Settings = new XmlWriterSettings
    {
      Indent = true,
      IndentChars = "    ",
      NewLineChars = Environment.NewLine,
      NewLineHandling = NewLineHandling.Replace,
    };

    public void Persist(object item, string directoryPath, string filename, bool overwrite)
    {
      if (_consoleDisplay == null)
      {
        _consoleDisplay = SimpleIoC.Container.Resolve<IOutput>();
        _validator = new InlineSchemaValidator();
        _validator.Subscribe(new SchemaValidationObserver(true, true, _consoleDisplay));
      }

      string p = Path.Combine(directoryPath, filename);
      if (overwrite || !File.Exists(p))
      {
        _consoleDisplay.Clear();
        _consoleDisplay.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} Saving {p}...");
        Directory.CreateDirectory(Path.GetDirectoryName(p));
        var serialiser = new XmlSerializer(item.GetType());
        using (var f = File.Create(p))
        using (XmlWriter writer = XmlWriter.Create(f, Settings))
        {
          serialiser.Serialize(writer, item);
        }
        _consoleDisplay.Clear();
        _consoleDisplay.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} Validating {p}...");
        _validator.ValidateFile(p);
      }
    }
  }
}
