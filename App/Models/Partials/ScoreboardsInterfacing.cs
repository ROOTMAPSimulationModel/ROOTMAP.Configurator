using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Scoreboards
{
  public partial class rootmap : IParent, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/ScoreboardsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Scoreboards.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public bool CanAdd => false;

    public bool CanRemove => false;

    public string ParentOwner => construction.owner;

    public dynamic CreateNewChild(int? index = null)
    {
      throw new NotSupportedException();
    }

    public IList<dynamic> GetChildren()
    {
      return new dynamic[] { construction.scoreboard };
    }

    public void RemoveChild(int index)
    {
      throw new NotSupportedException();
    }

    public void OverrideOwner(string owner)
    { }
  }
}
