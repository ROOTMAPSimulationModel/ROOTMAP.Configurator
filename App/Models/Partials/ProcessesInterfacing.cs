using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Processes
{
  public partial class rootmap : MultipleChildModelBase<ProcessesProcess>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/ProcessesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Processes.xsd";


    // N.B. We're never going to want to be able to "add/remove new Processes" with the config app.
    // Adding or removing Processes requires modifying ROOTMAP itself.
    public override bool CanAdd => false;
    public override bool CanRemove => false;

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? construction.owner;

    public override IList<dynamic> GetChildren()
    {
      if (construction.process == null)
      {
        construction.process = new ProcessesProcess[] { };
      }
      return construction.process;
    }

    public override void RemoveChild(int index)
    {
      throw new NotImplementedException("Cannot remove Processes through the configuration app.");
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      throw new NotImplementedException("Cannot define new Processes through the configuration app. New processes must be implemented in ROOTMAP itself, and their configuration elements should be developed in XML directly.");
    }
  }
}
