﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardScoreboardBoundaries : ICreate, ICreateStandard<Scoreboards.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardsSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Scoreboards.xsd"">
    <construction>
        <owner>ScoreboardCoordinator</owner>
        <scoreboard>
            <name>Soil</name>
            <stratum>2</stratum>
            <boundaryarray>
                <dimension>X</dimension>
                <!-- NOTE that the positionarray does not have any  -->
                <!-- whitespace between the first and last elements,0,1,2,3,4,5,6,7,8,9,10-->
                <!-- only commas                     -->
                <positionarray>0,2,4,6,8,10,12,14,16</positionarray>
            </boundaryarray>
            <boundaryarray>
                <dimension>Y</dimension>
                <positionarray>0,2,4,6,8,10,12,14,16</positionarray>
            </boundaryarray>
            <boundaryarray>
                <dimension>Z</dimension>
                <positionarray>
0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42
                </positionarray>
            </boundaryarray>
        </scoreboard>
    </construction>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}
