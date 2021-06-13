using CommandLine;

namespace Rootmap.ConfigurationImporter
{
  public class Options
  {
    [Value(0, MetaName = "path", HelpText = "Path to the target file or directory. Defaults to the current directory.")]
    public string Path { get; set; } = ".";

    [Option('v', "verbose", Required = false,
      HelpText = "Output detailed information.")]
    public bool Verbose { get; set; }
  }
}
