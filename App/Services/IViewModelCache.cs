using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator.Services
{
  public interface IViewModelCache
  {
    /// <summary>
    /// Gets the matching viewmodel, if it exists.
    /// </summary>
    BaseViewModel Get(string modelFilename, string owner, int? index);

    /// <summary>
    /// Registers a view model that has been accessed via a field. Calls back to the BaseViewModel to look up the current ("initial") value of the field in question.
    /// </summary>
    void Put(string modelFilename, string owner, int? index, BaseViewModel vm);
  }
}
