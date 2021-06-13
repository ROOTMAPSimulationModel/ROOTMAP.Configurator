﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardMain : ICreate, ICreateStandard<Main.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<rootmap
   xmlns=""https://example.org/ROOTMAP/MainSchema""
   xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/MainSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Main.xsd"">
    <configuration>
        <name>Scoreboard Boundaries</name>
        <type>construction</type>
        <owner>ScoreboardCoordinator</owner>
        <location>Scoreboards.xml</location>
    </configuration>
    <configuration>
        <name>Volume Objects</name>
        <type>construction</type>
        <owner>VolumeObjectCoordinator</owner>
        <location>VolumeObjects.xml</location>
    </configuration>
    <configuration>
        <name>Plant Attributes</name>
        <type>construction</type>
        <owner>SharedAttributeManager</owner>
        <location>shared_attributes/PlantAttributes.xml</location>
    </configuration>
    <configuration>
        <name>Nitrate Attributes</name>
        <type>construction</type>
        <owner>SharedAttributeManager</owner>
        <location>shared_attributes/NitrateAttributes.xml</location>
    </configuration>
    <configuration>
        <name>Phosphorus Attributes</name>
        <type>construction</type>
        <owner>SharedAttributeManager</owner>
        <location>shared_attributes/PhosphorusAttributes.xml</location>
    </configuration>
    <configuration>
        <name>Water Attributes</name>
        <type>construction</type>
        <owner>SharedAttributeManager</owner>
        <location>shared_attributes/WaterAttributes.xml</location>
    </configuration>
    <configuration>
        <name>Post Office</name>
        <type>construction</type>
        <owner>PostOffice</owner>
        <location>PostOffice.xml</location>
    </configuration>
    <configuration>
        <name>Plant Types</name>
        <type>construction</type>
        <owner>PlantCoordinator</owner>
        <location>process_data/PlantTypes.xml</location>
    </configuration>
    <configuration>
        <name>Plants</name>
        <type>construction</type>
        <owner>PlantCoordinator</owner>
        <location>process_data/Plants.xml</location>
    </configuration>
    <configuration>
        <name>Processes</name>
        <type>construction</type>
        <owner>ProcessCoordinator</owner>
        <location>process_data/Processes.xml</location>
    </configuration>

    <configuration>
        <name>Plant Initial Values</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>shared_attributes/PlantAttributeInitialValues.xml</location>
    </configuration>
    <configuration>
        <name>Nitrate Initial Values</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>shared_attributes/NitrateAttributeInitialValues.xml</location>
    </configuration>
    <configuration>
        <name>Phosphorus Initial Values</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>shared_attributes/PhosphorusAttributeInitialValues.xml</location>
    </configuration>
    <configuration>
        <name>Water Initial Values</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>shared_attributes/WaterAttributeInitialValues.xml</location>
    </configuration>
    <configuration>
        <name>Phosphorus Initial Data</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>scoreboard_data/PhosphorusData.xml</location>
    </configuration>
    <configuration>
        <name>Nitrate Initialisation Data</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>scoreboard_data/NitrateAmount.xml</location>
    </configuration>
    <configuration>
        <name>Bulk Density Initialisation</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>scoreboard_data/BulkDensity.xml</location>
    </configuration>
    <configuration>
        <name>Water Initialisation Data</name>
        <type>initialisation</type>
        <owner>Scoreboard</owner>
        <location>scoreboard_data/SoilWaterContent.xml</location>
    </configuration>
    <configuration>
        <name>Water Rainfall Initialisation</name>
        <type>initialisation</type>
        <owner>Water</owner>
        <location>process_data/RainfallEvents.xml</location>
    </configuration>
    <configuration>
        <name>Output Rules</name>
        <type>initialisation</type>
        <owner>DataOutputCoordinator</owner>
        <location>OutputRules.xml</location>
    </configuration>
    <configuration>
        <name>Renderer Configuration</name>
        <type>initialisation</type>
        <owner>RenderCoordinator</owner>
        <location>Renderer.xml</location>
    </configuration>

    <configuration>
        <name>Tables</name>
        <type>visualisation</type>
        <owner>TableCoordinator</owner>
        <location>Windows.xml</location>
    </configuration>
    <configuration>
        <name>Views</name>
        <type>visualisation</type>
        <owner>ViewCoordinator</owner>
        <location>Windows.xml</location>
    </configuration>
    <configuration>
        <name>View3D</name>
        <type>visualisation</type>
        <owner>View3DCoordinator</owner>
        <location>Windows.xml</location>
    </configuration>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}
