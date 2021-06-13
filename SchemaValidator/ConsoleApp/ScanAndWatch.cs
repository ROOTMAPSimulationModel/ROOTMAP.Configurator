using System.IO;
using Rootmap.SchemaValidator.Validator;

namespace Rootmap.SchemaValidator.FilesystemWatcher
{
  public partial class Scan
  {
    public static void Watch(WatchOptions options, IO.IOutput output, IO.IInput input)
    {
      var path = Path.GetFullPath(options.Path);
      var isDir = Directory.Exists(path);
      var isFile = File.Exists(path);
      if (isDir || isFile)
      {
        if (!options.NoImmediateScan)
        {
          Scan.Once(new OnceOptions
          {
            Path = options.Path,
            Strict = options.Strict,
            Verbose = options.Verbose
          }, output);
        }
        output.WriteLine(isFile
            ? $"> Watching for changes in file {path}."
            : $"> Watching for XML file changes in {path}.");
        output.WriteLine("> Type 'exit' or close the terminal window to exit.");
        output.WriteLine();

        var observer = new FileChangeObserver(new InlineSchemaValidator(), new SchemaValidationObserver(options.Strict, options.Verbose, output), output, options.Incremental ? null : options.Path);

        using (FileSystemWatcher watcher = new FileSystemWatcher(path)
        {
          IncludeSubdirectories = true,
          Filter = "*.xml"
        })
        {
          // Only watch for changes to Creation and LastWrite times.
          // Renaming, moving, reading etc. don't affect the content
          // and thus do not necessitate validation.
          watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;

          // Add event handlers.
          watcher.Changed += (o, e) =>
          {
            observer.OnNext(e);
          };
          watcher.Created += (o, e) =>
          {
            observer.OnNext(e);
          };
          watcher.Deleted += (o, e) =>
          {
            observer.OnNext(e);
          };
          watcher.Renamed += (o, e) =>
          {
            observer.OnNext(e);
          };
          watcher.Error += (o, e) =>
          {
            observer.OnError(e.GetException());
          };

          // Begin watching.
          watcher.EnableRaisingEvents = true;

          while (input.ReadLine()?.ToLowerInvariant().Trim() != "exit") ;
        }
      }
      else
      {
        output.WriteLine($"Path {path} does not exist.");
      }
    }
  }
}
