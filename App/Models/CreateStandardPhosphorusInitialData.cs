﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardPhosphorusInitialData : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!-- Soil P for modelling lupin root growth in pots, simulations in sandy soil -->
<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <scoreboarddata>
            <!-- Added P µgP/g soil, top dressed fertiliser = P mixed through the top 3cm of soil -->
            <process>Phosphorus</process>
            <characteristic>Added P VolumeObject [none]</characteristic>
            <scheme>
        set scoreboard value=0;
            </scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Phosphorus</process>
            <!-- Total Labile P µgP/g in each soil cube, or µgP/mL for nutrient solution simulations-->
            <characteristic>Total Labile P VolumeObject [none]</characteristic>
            <scheme>
        set scoreboard value=7.35;
            </scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Phosphorus</process>
            <!-- Total Labile P µgP/g in each soil cube, or µgP/mL for nutrient solution simulations-->
            <characteristic>Total Labile P VolumeObject 1</characteristic>
            <scheme>
        set scoreboard value=7.35;
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
