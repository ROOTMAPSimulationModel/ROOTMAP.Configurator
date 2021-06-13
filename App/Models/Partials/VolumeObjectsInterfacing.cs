using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.VolumeObjects
{
  public partial class rootmap : MultipleChildModelBase<VolumeObject>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/VolumeObjectsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/VolumeObjects.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? construction.owner;

    private void AddChild(VolumeObject newChild, int? index)
    {
      construction.volumeobject = AddChildImpl(construction.volumeobject, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (construction.volumeobject == null)
      {
        construction.volumeobject = new VolumeObject[] { };
      }
      return construction.volumeobject;
    }

    public override void RemoveChild(int index)
    {
      construction.volumeobject = RemoveChildImpl(construction.volumeobject, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var newChild = new VolumeObject();
      AddChild(newChild, index);
      return newChild;
    }
  }

  public partial class VolumeObject
  {
    public VolumeObject()
    {
      class_name = VolumeObjectClass_name.BoundingCylinder;
      depth = 0;
      depthSpecified = true;
      origin = "0,0,0";
      permeability = new VolumeObjectPermeability();
      radius = 1;
      radiusSpecified = true;
      root_penetration_probability = new VolumeObjectRoot_penetration_probability();
    }
  }
}
