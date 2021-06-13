using System.Collections.Generic;

namespace Rootmap.Configurator.Schema
{
  public interface ITopLevel
  {
    IEnumerable<IParent> GetCollectionEntities();
  }
}
