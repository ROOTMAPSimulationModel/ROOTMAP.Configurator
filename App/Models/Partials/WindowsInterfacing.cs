using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Windows
{
  public partial class rootmap : MultipleChildModelBase<Visualisation>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/WindowsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Windows.xsd";

    public override string ParentOwner => _overrideOwner
        ?? visualisation
            .FirstOrDefault()?
            .owner
            .ToString();

    private void AddChild(Visualisation newChild, int? index)
    {
      visualisation = AddChildImpl(visualisation, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (visualisation == null)
      {
        visualisation = new Visualisation[] { };
      }
      return visualisation;
    }

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override void RemoveChild(int index)
    {
      visualisation = RemoveChildImpl(visualisation, index)
          .ToArray();
    }
    public override dynamic CreateNewChild(int? index = null)
    {
      var child = new Visualisation(_overrideOwner);
      AddChild(child, index);
      return child;
    }
  }

  public partial class Visualisation
  {
    private Visualisation() { }

    public Visualisation(string theOwner)
    {
      switch (theOwner)
      {
        case "TableCoordinator":
          owner = ViewOwner.TableCoordinator;
          Item = new Table();
          break;
        case "View3DCoordinator":
          owner = ViewOwner.View3DCoordinator;
          Item = new View3D();
          break;
        case "ViewCoordinator":
          owner = ViewOwner.ViewCoordinator;
          Item = new View
          {
            characteristics = new Characteristics
            {
              cyan = new CharacteristicColourInfo(),
              magenta = new CharacteristicColourInfo(),
              yellow = new CharacteristicColourInfo()
            }
          };
          break;
        default:
          throw new ArgumentException("Visualisation owner must be TableCoordinator, View3DCoordinator or ViewCoordinator.", nameof(theOwner));
      }
    }
  }
}
