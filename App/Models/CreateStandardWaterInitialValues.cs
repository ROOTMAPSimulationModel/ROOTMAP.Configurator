﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardWaterInitialValues : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <scoreboarddata>
            <!-- Water SharedAttributes -->
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder0 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder1 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder2 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>

        <scoreboarddata>
            <!-- Water SharedAttributes -->
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder0 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder1 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 1 RootOrder2 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <!-- Water SharedAttributes -->
            <process>Water</process>
            <characteristic>Water Flux Plant 2 RootOrder0 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 2 RootOrder1 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 2 RootOrder2 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <!-- Water SharedAttributes -->
            <process>Water</process>
            <characteristic>Water Flux Plant 3 RootOrder0 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 3 RootOrder1 VolumeObject 1</characteristic>
            <scheme>set scoreboard value=0.00;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>Water</process>
            <characteristic>Water Flux Plant 3 RootOrder2 VolumeObject 1</characteristic>
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
