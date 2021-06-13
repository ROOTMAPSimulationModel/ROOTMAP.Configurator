using System;
using System.Collections.Generic;

namespace Rootmap.Configurator.Schema
{
  public interface IParent
  {
    string ParentOwner { get; }
    IList<dynamic> GetChildren();
    bool CanAdd { get; }
    bool CanRemove { get; }
    dynamic CreateNewChild(int? index = null);
    void RemoveChild(int index);
    void OverrideOwner(string owner);
  }
}
