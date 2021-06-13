namespace Rootmap.Configurator.Services
{
  public interface IPersister
  {
    /// <summary>
    /// Saves an item to file
    /// </summary>
    /// <param name="item"></param>
    /// <param name="directoryPath"></param>
    /// <param name="filename"></param>
    /// <param name="overwrite"></param>
    void Persist(object item, string directoryPath, string filename, bool overwrite);
  }
}
