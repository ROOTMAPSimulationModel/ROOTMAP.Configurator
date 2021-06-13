using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.PostOffice
{
  public partial class rootmap : IParent, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/PostOfficeSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/PostOffice.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public bool CanAdd => false;

    public bool CanRemove => false;

    public string ParentOwner => construction.owner;

    public dynamic CreateNewChild(int? index = null) => throw new System.NotSupportedException();

    public IList<dynamic> GetChildren()
    {
      return new dynamic[] { construction.postoffice };
    }

    public void RemoveChild(int index) => throw new System.NotSupportedException();

    public void OverrideOwner(string owner)
    { }
  }
}
