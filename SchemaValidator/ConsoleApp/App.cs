using CommandLine;

namespace Rootmap.SchemaValidator.FilesystemWatcher
{
  public class App
  {
    private static readonly IO.Console Console = new IO.Console();

    public static void Main(string[] args)
    {
      var result = Parser.Default.ParseArguments<OnceOptions, WatchOptions>(args)
        .WithParsed<OnceOptions>(options => Scan.Once(options, Console))
        .WithParsed<WatchOptions>(options => Scan.Watch(options, Console, Console));
    }
  }
}
