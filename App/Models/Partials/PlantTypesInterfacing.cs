using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.PlantTypes
{
  public partial class rootmap : MultipleChildModelBase<PlantTypesPlanttype>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/PlantTypesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/PlantTypes.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? construction.owner;

    private void AddChild(PlantTypesPlanttype newChild, int? index)
    {
      construction.planttype = AddChildImpl(construction.planttype, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (construction.planttype == null)
      {
        construction.planttype = new PlantTypesPlanttype[] { };
      }
      return construction.planttype;
    }

    public override void RemoveChild(int index)
    {
      construction.planttype = RemoveChildImpl(construction.planttype, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var newChild = new PlantTypesPlanttype();
      AddChild(newChild, index);
      return newChild;
    }
  }

  public partial class PlantTypesPlanttype
  {
    public PlantTypesPlanttype()
    {
      first_seminal_probability = 1;
      germination_lag = 1;
      initial_seminal_deflection = 1;
      name = "New Plant Type";
      roots_to_foliage_ratio = 1;
      structure_to_photosynthesize_ratio = 1;
      temperature_of_zero_growth = 7;
      vegetate_to_reproduce_ratio = 1;
    }
  }
}
