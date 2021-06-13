using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.RainfallEvents
{
  public partial class rootmap : IParent, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/RainfallEventsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/RainfallEvents.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public string ParentOwner => initialisation.owner;

    public bool CanAdd => false;

    public bool CanRemove => false;

    private void AddChild(RainfallEventsData newChild, int? index)
    {
      throw new System.NotSupportedException();
    }

    public IList<dynamic> GetChildren()
    {
      return new dynamic[] { initialisation.data };
    }

    public void RemoveChild(int index)
    {
      throw new System.NotSupportedException();
    }

    public dynamic CreateNewChild(int? index = null)
    {
      throw new NotSupportedException();
    }

    public void OverrideOwner(string owner)
    { }
  }
}
