﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardNitrateInitialisationData : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <scoreboarddata>
            <!-- Nitrate Amount &#x3BC;ugN during the simulation, initially input as ugN/g, same for both the Yellow Sand and Vertosol Soil simulations-->
            <process>Nitrate</process>
            <characteristic>Nitrate Amount VolumeObject [none]</characteristic>
            <scheme>
        set scoreboard value=4.7;
            </scheme>
        </scoreboarddata>
        <scoreboarddata>
            <!-- Nitrate Amount &#x3BC;ugN during the simulation, initially input as ugN/g, same for both the Yellow Sand and Vertosol Soil simulations-->
            <process>Nitrate</process>
            <characteristic>Nitrate Amount VolumeObject 1</characteristic>
            <scheme>
        set scoreboard value=4.7;
            </scheme>
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
