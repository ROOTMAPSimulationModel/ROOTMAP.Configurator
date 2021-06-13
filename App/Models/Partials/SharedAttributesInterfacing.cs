using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.SharedAttributes
{
  public partial class rootmap : MultipleChildModelBase<SharedAttributesAttribute>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/SharedAttributesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/SharedAttributes.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? construction.owner;

    private void AddChild(SharedAttributesAttribute newChild, int? index)
    {
      construction.attribute = AddChildImpl(construction.attribute, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (construction.attribute == null)
      {
        construction.attribute = new SharedAttributesAttribute[] { };
      }
      return construction.attribute;
    }

    public override void RemoveChild(int index)
    {
      construction.attribute = RemoveChildImpl(construction.attribute, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var child = new SharedAttributesAttribute();
      AddChild(child, index);
      return child;
    }
  }

  public partial class SharedAttributesAttribute
  {
    public SharedAttributesAttribute()
    {
      characteristic_descriptor = new Characteristic
      {
        @default = 96,
        editable = true,
        maximum = double.MaxValue,
        minimum = 0,
        name = "Seminal Branch Lag Time",
        stratum = "Soil",
        tobesaved = true,
        units = "hours",
        visible = true
      };
      defaults = new Defaults
      {
        variation_name = "RootOrder",
        values = "72.0,240.0,1200.0,3000.0"
      };
      owner = "PlantCoordinator";
      storage = "Scoreboard";
      variations = "Plant,RootOrder,VolumeObject";
    }
  }
}
