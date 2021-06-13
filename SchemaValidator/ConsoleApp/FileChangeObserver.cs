using System;
using System.IO;
using Rootmap.IO;
using Rootmap.SchemaValidator.Validator;

namespace Rootmap.SchemaValidator.FilesystemWatcher
{
  public class FileChangeObserver : IObserver<FileSystemEventArgs>
  {
    private readonly ISchemaValidator _schemaValidator = new InlineSchemaValidator();
    private readonly SchemaValidationObserver _validationObserver;
    private readonly IOutput _console;
    private readonly string _onChangeValidationPath = null;

    /// <summary>
    /// Creates and initialises an object which reacts to file changes.
    /// </summary>
    /// <param name="schemaValidator"></param>
    /// <param name="schemaValidationObserver"></param>
    /// <param name="console"></param>
    /// <param name="onChangeValidationPath">Optional. If provided, this whole path will be validated on change. If not, only the changed file will be validated.</param>
    public FileChangeObserver(ISchemaValidator schemaValidator, SchemaValidationObserver schemaValidationObserver, IOutput console, string onChangeValidationPath = null)
    {
      _console = console;
      _schemaValidator = schemaValidator;
      _validationObserver = schemaValidationObserver;
      _onChangeValidationPath = onChangeValidationPath;

      _schemaValidator.Subscribe(_validationObserver);
    }

    public void OnCompleted() => _console.WriteLine("> File system watcher completed.");

    public void OnError(Exception error) => _console.WriteLine($"> File system watcher encountered an error: {error.Message}");

    public void OnNext(FileSystemEventArgs value)
    {
      if (Directory.Exists(_onChangeValidationPath))
      {
        _console.Clear();
        _console.WriteLine($"> Changes detected in {value.FullPath}.");
        var xmlFiles = Directory.EnumerateFiles(_onChangeValidationPath, "*.xml", SearchOption.AllDirectories);
        foreach (string file in xmlFiles)
        {
          _schemaValidator.ValidateFile(file);
        }
        _console.WriteLine("> Full rescan complete.");
      }
      else
      {
        _console.WriteLine($"> Changes detected in {value.FullPath}.");
        _schemaValidator.ValidateFile(value.FullPath);
      }
    }
  }
}
