using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Renderer
{
  public partial class rootmap : ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/RendererSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Renderer.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new Renderer[] { initialisation };
    }
  }

  public partial class Renderer : MultipleChildModelBase<CharacteristicColourInfo>
  {
    public override string ParentOwner => _overrideOwner
        ?? owner;

    public override IList<dynamic> GetChildren()
    {
      if (characteristic_colour_info == null)
      {
        characteristic_colour_info = new CharacteristicColourInfo[] { };
      }
      return characteristic_colour_info;
    }

    private void AddChild(CharacteristicColourInfo newChild, int? index)
    {
      characteristic_colour_info = AddChildImpl(characteristic_colour_info, newChild, index)
          .ToArray();
    }

    public override void RemoveChild(int index)
    {
      characteristic_colour_info = RemoveChildImpl(characteristic_colour_info, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var newChild = new CharacteristicColourInfo();
      AddChild(newChild, index);
      return newChild;
    }
  }
}
