﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardBulkDensityInitialData : ICreate, ICreateStandard<ScoreboardData.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/ScoreboardDataSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/ScoreboardDataSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/ScoreboardData.xsd"">
    <initialisation>
        <owner>Scoreboard</owner>
        <scoreboarddata>
            <!-- Bulk Density g/cm3, same for both the Yellow Sand and the Vetosol Soil simulations -->
            <process>Bulk Density</process>
            <characteristic>Bulk Density VolumeObject [none]</characteristic>
            <scheme>
        set scoreboard value=1.0;
            </scheme>
        </scoreboarddata>
        <scoreboarddata>
            <!-- Bulk Density g/cm3, same for both the Yellow Sand and the Vetosol Soil simulations -->
            <process>Bulk Density</process>
            <characteristic>Bulk Density VolumeObject 1</characteristic>
            <scheme>
        set scoreboard value=1.0;
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
