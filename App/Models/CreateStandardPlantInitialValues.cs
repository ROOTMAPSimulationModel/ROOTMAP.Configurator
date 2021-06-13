﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardPlantInitialValues : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>

<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <!-- Plant SharedAttributes -->
        <!-- Growth Rate per-Plant per-RootOrder -->
        <scoreboarddata>
            <process>PlantCoordinator</process>
            <characteristic>Root P Plasticity Factor Plant 1 RootOrder0 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=1.0;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>PlantCoordinator</process>
            <characteristic>Root P Plasticity Factor Plant 1 RootOrder1 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=1.0;</scheme>
        </scoreboarddata>
        <scoreboarddata>
            <process>PlantCoordinator</process>
            <characteristic>Root P Plasticity Factor Plant 1 RootOrder2 VolumeObject [none]</characteristic>
            <scheme>set scoreboard value=1.0;</scheme>
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
