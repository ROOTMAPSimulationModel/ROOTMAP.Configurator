using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.ScoreboardData
{
  public partial class rootmap : ITopLevel
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd";

    public IEnumerable<IParent> GetCollectionEntities()
    {
      return initialisation;
    }
  }

  public partial class ScoreboardData : MultipleChildModelBase<ScoreboardDataScoreboarddata>
  {
    public override string ParentOwner => _overrideOwner
        ?? owner;

    private void AddChild(ScoreboardDataScoreboarddata newChild, int? index)
    {
      scoreboarddata = AddChildImpl(scoreboarddata, newChild, index)
          .ToArray();
    }

    public override IList<dynamic> GetChildren()
    {
      if (scoreboarddata == null)
      {
        scoreboarddata = new ScoreboardDataScoreboarddata[] { };
      }
      return scoreboarddata;
    }

    public override void RemoveChild(int index)
    {
      scoreboarddata = RemoveChildImpl(scoreboarddata, index)
          .ToArray();
    }

    public override dynamic CreateNewChild(int? index = null)
    {
      var child = new ScoreboardDataScoreboarddata();
      AddChild(child, index);
      return child;
    }
  }

  public partial class ScoreboardDataScoreboarddata
  {
    public ScoreboardDataScoreboarddata()
    {
      characteristic = "Nitrate Concentration";
      process = "Nitrate";
      scheme = "set scoreboard value=1.0;";
    }
  }
}
