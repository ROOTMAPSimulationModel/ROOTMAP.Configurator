using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Plants
{
  public partial class rootmap : MultipleChildModelBase<PlantsPlant>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/PlantsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Plants.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? construction.owner;

    private void AddChild(PlantsPlant newChild, int? index)
    {
      construction.plant = AddChildImpl(construction.plant, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (construction.plant == null)
      {
        construction.plant = new PlantsPlant[] { };
      }
      return construction.plant;
    }

    public override void RemoveChild(int index)
    {
      construction.plant = RemoveChildImpl(construction.plant, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var newChild = new PlantsPlant();
      AddChild(newChild, index);
      return newChild;
    }
  }

  public partial class PlantsPlant
  {
    public PlantsPlant()
    {
      nodal_axis = new Axis[]
      {
                new Axis()
      };
      origin = "0,0,0";
      seeding_time = 0m;
      seed_location = "0,0,0";
      seminal_axis = new Axis[]
      {
                new Axis()
      };
    }
  }
}
