using CommandLine;

namespace Rootmap.SchemaValidator.FilesystemWatcher
{
  public abstract class CommonOptions
  {
    [Value(0, MetaName = "path", HelpText = "Path to the target file or directory. Defaults to the current directory.")]
    public string Path { get; set; } = ".";

    [Option('s', "strict", Required = false,
      HelpText = "Validate for warnings as well as errors.")]
    public bool Strict { get; set; } = false;

    [Option('v', "verbose", Required = false,
      HelpText = "Output detailed information.")]
    public bool Verbose { get; set; } = false;
  }

  [Verb("once",
    HelpText = "Scan and validate the target file or directory.")]
  public sealed class OnceOptions : CommonOptions
  { }

  [Verb("watch",
    HelpText = "Watch the target file or directory and validate on change.")]
  public sealed class WatchOptions : CommonOptions
  {
    [Option('n', "no-immediate-scan", Required = false,
      HelpText = "Do not perform an immediate scan of the target file or directory. Respond to file changes only.")]
    public bool NoImmediateScan { get; set; } = false;

    [Option('i', "incremental", Required = false,
      HelpText = "When a file changes, rescan that file only. If this flag is not set, the entire directory will be rescanned when a file changes.")]
    public bool Incremental { get; set; } = false;
  }
}
