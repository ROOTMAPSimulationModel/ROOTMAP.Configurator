using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Rootmap.SchemaValidator.Validator;

namespace Rootmap.SchemaValidator.FilesystemWatcher
{
  public partial class Scan
  {
    public static void Once(OnceOptions options, IO.IOutput output)
    {
      var validator = new InlineSchemaValidator();
      validator.Subscribe(new SchemaValidationObserver(options.Strict, options.Verbose, output));
      var path = System.IO.Path.GetFullPath(options.Path);
      var isFile = File.Exists(path);

      if (isFile)
      {
        output.WriteLine($"Scan: validating single file{Environment.NewLine}{path}");
        validator.ValidateFile(path);
      }
      else
      {
        output.WriteLine($"Scan: validating directory{Environment.NewLine}{path}");
        var tokenSource = new CancellationTokenSource();
        var cancelToken = tokenSource.Token;
        WarnIfSlow(output, cancelToken);
        ResultSummary scanResults = ScanDirectory(output, options, validator, path);
        tokenSource.Cancel();
        if (scanResults.ErrorCount > 0 && !options.Strict)
        {
          output.WriteLine($"Scan complete with {scanResults.ErrorCount} error(s).");
        }
        else if (scanResults.ErrorCount > 0 || (scanResults.WarningCount > 0 && options.Strict))
        {
          output.WriteLine($"Scan complete with {scanResults.ErrorCount} error(s), {scanResults.WarningCount} warning(s).");
        }
        else
        {
          output.WriteLine("Scan completed, no problems found.");
        }
      }
    }

    private static ResultSummary ScanDirectory(IO.IOutput output, CommonOptions options, InlineSchemaValidator validator, string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentNullException(nameof(path));
      }
      if (!Directory.Exists(path))
      {
        throw new ArgumentException("Path to scan must be a directory.", nameof(path));
      }
      var xmlFiles = Directory.EnumerateFiles(path, "*.xml", SearchOption.AllDirectories);
      var initialResults = new ResultSummary();
      foreach (var file in xmlFiles)
      {
        if (options.Verbose)
        {
          output.WriteLine($"Scan: validating{Environment.NewLine}{file}");
        }
        var results = validator.ValidateFile(file);
        initialResults.ErrorCount += results.ErrorCount;
        initialResults.WarningCount += results.WarningCount;
      }

      return initialResults;
    }

    private static async void WarnIfSlow(IO.IOutput output, CancellationToken cancelToken)
    {
      try
      {
        await Task.Delay(1500, cancelToken);
      }
      catch (TaskCanceledException)
      { }
      if (!cancelToken.IsCancellationRequested)
      {
        output.WriteLine("Scan is taking some time...");
      }
    }
  }
}
