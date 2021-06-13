using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.OutputRules
{
  public partial class rootmap : MultipleChildModelBase<OutputRule>, ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/OutputRulesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/OutputRules.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return new rootmap[] { this };
    }

    public override string ParentOwner => _overrideOwner
        ?? initialisation.owner;

    private void AddChild(OutputRule newChild, int? index)
    {
      initialisation.outputrule = AddChildImpl(initialisation.outputrule, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (initialisation.outputrule == null)
      {
        initialisation.outputrule = new OutputRule[] { };
      }
      return initialisation.outputrule;
    }

    public override void RemoveChild(int index)
    {
      initialisation.outputrule = RemoveChildImpl(initialisation.outputrule, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var newChild = new OutputRule();
      AddChild(newChild, index);
      return newChild;
    }
  }

  public partial class OutputRule
  {
    // Validly initialise all new OutputRules.
    public OutputRule()
    {
      characteristic = "Root Length Wrap None Plant 1";
      filename = "NewOutputRule.txt";
      reopen = OutputRuleReopen.append;
      source = "PlantCoordinator";
      specification1 = "X,Z,Y";
      stratum = "Soil";
      type = "ScoreboardData";
      when = new When
      {
        count = 0,
        initialtime = "0,0,0,0,0,0",
        ItemElementName = ItemChoiceType.interval
      };
    }
  }
}
