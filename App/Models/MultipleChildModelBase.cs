using System;
using System.Collections.Generic;
using System.Linq;

namespace Rootmap.Configurator.Schema
{
  public abstract partial class MultipleChildModelBase<TChild> : IParent
  {
    protected string _overrideOwner;

    public abstract string ParentOwner { get; }
    public abstract IList<dynamic> GetChildren();
    public abstract dynamic CreateNewChild(int? index);
    public abstract void RemoveChild(int index);

    public virtual bool CanAdd => true;
    public virtual bool CanRemove => true;

    protected IEnumerable<TChild> AddChildImpl(IEnumerable<TChild> children, TChild newChild, int? index = null)
    {
      var kids = children.ToList();
      if (index.HasValue)
      {
        if (index >= kids.Count)
        {
          throw new ArgumentOutOfRangeException(nameof(index), $"Collection does not contain {index + 1} elements.");
        }
        if (index < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(index));
        }
        kids.Insert(index.Value, newChild);
      }
      else
      {
        kids.Add(newChild);
      }
      return kids;
    }

    protected IEnumerable<TChild> RemoveChildImpl(IEnumerable<TChild> children, int index)
    {
      if (index >= children.Count())
      {
        throw new ArgumentOutOfRangeException(nameof(index), $"Collection does not contain {index + 1} elements.");
      }
      if (index < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }
      return children
          .Where((x, i) => i != index)
          .ToArray();
    }

    public void OverrideOwner(string owner) => _overrideOwner = owner;
  }
}
