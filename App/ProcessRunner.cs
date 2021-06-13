using System.Diagnostics;
using System.Threading.Tasks;
using NLog;

namespace Rootmap.Configurator
{
  public class ProcessRunner
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();

    private readonly string _path;

    public ProcessRunner(string pathToExecutable)
    {
      _path = pathToExecutable;
    }

    public Task<string> Run(string pathToConfiguration)
    {
      return Task.Run(() =>
      {
        try
        {
          var process = new System.Diagnostics.Process();
          // Configure the process using the StartInfo properties.
          process.StartInfo.FileName = _path;
          process.StartInfo.Arguments = $"--config-dir={pathToConfiguration}";
          process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
          logger.Info($"Launching {process.StartInfo.FileName} with argument(s) '{process.StartInfo.Arguments}'");
          process.Start();
          process.WaitForExit();
          return string.Empty;
        }
        catch (System.Exception e)
        {
          logger.Error(e, "Could not successfully run ROOTMAP.");
          return e.Message;
        }
      });
    }
  }
}
