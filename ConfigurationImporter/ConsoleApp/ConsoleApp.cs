using System;
using CommandLine;
using Rootmap.IO;

namespace Rootmap.ConfigurationImporter
{
  public static class ConsoleApp
  {
    private static readonly IO.Console Output = new IO.Console();

    public static void Main(string[] args)
    {
      var result = Parser.Default.ParseArguments<Options>(args)
          .WithParsed(opt => Run(Output, opt));
    }

    private static void Run(IOutput output, Options options)
    {
      var path = System.IO.Path.GetFullPath(options.Path.TrimEnd('\\', '/'));
      if (!System.IO.Directory.Exists(path))
      {
        output.WriteLine($"Directory {path} does not exist.");
      }
      else
      {
        try
        {
          var outcomes = ConfigurationTransformer.transformAllFiles(path);

          foreach (var o in outcomes)
          {
            if (!o.Item2)
            {
              output.WriteLine($"FAILURE: {o.Item1}");
            }
            else if (options.Verbose)
            {
              output.WriteLine($"SUCCESS: {o.Item1}");
            }
          }
          output.WriteLine();
          output.WriteLine($"Finished importing ROOTMAP configuration files in {path}.");
        }
        catch (Exception e)
        {
          output.WriteLine($"Error: {e.Message}");
        }
      }
    }
  }
}
