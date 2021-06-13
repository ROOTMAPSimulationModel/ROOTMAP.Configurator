namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardNitrateInitialValues : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>

<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <scoreboarddata>
          <process>Nitrate</process>
          <characteristic>Plant Nitrate Uptake Plant 1</characteristic>
          <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        </initialisation>
</rootmap>
";

    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}
