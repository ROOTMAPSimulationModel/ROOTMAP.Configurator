using System.Collections.Generic;
using NLog;
using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator.Services
{
  /// <summary>
  /// Very simple implementation of IViewModelCache. Does not persist anything to disk; works only within a single session of the application. Not a fully-featured cache, has no capacity for expiring items etc.
  /// </summary>
  public class VolatileViewModelStore : IViewModelCache
  {
    private static Logger logger = LogManager.GetCurrentClassLogger();
    private Dictionary<string, BaseViewModel> _store = new Dictionary<string, BaseViewModel>();

    public BaseViewModel Get(string modelFilename, string owner, int? index)
    {
      var key = $"{modelFilename}|{owner}|{index}";
      return _store.ContainsKey(key) ? _store[key] : null;
    }

    public void Put(string modelFilename, string owner, int? index, BaseViewModel vm)
    {
      var key = $"{modelFilename}|{owner}|{index}";
      _store[key] = vm;
    }
  }
}
