namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardPlants : ICreate, ICreateStandard<Plants.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""US-ASCII"" standalone=""yes""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/PlantsSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/PlantsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Plants.xsd"">
    <construction>
        <owner>PlantCoordinator</owner>
        <plant>
            <name>Plant 1</name>
            <type>RootMap Plant Type</type>
            <!-- origin and seed_location are X,Y,Z no spaces -->
            <origin>4.5,8.0,0.0</origin>
            <seed_location>4.5,8.0,0.5</seed_location>
            <!-- seeding time is in days from time zero -->
            <seeding_time>1.0</seeding_time>
            <seminal_axis>
                <start_lag>1.0</start_lag>
                <probability>1.0</probability>
            </seminal_axis>
            <seminal_axis>
                <start_lag>3.0</start_lag>
                <probability>0.0</probability>
            </seminal_axis>
            <seminal_axis>
                <start_lag>4.0</start_lag>
                <probability>0.0</probability>
            </seminal_axis>
            <nodal_axis>
                <start_lag>1.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
            <nodal_axis>
                <start_lag>3.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
            <nodal_axis>
                <start_lag>4.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
        </plant>
        <plant>
            <name>Plant 2</name>
            <type>RootMap Plant Type</type>
            <!-- origin and seed_location are X,Y,Z no spaces -->
            <origin>11.5,8.0,0.0</origin>
            <seed_location>11.5,8.0,0.5</seed_location>
            <!-- seeding time is in days from time zero -->
            <seeding_time>1.0</seeding_time>
            <seminal_axis>
                <start_lag>1.0</start_lag>
                <probability>1.0</probability>
            </seminal_axis>
            <seminal_axis>
                <start_lag>3.0</start_lag>
                <probability>0.0</probability>
            </seminal_axis>
            <seminal_axis>
                <start_lag>4.0</start_lag>
                <probability>0.0</probability>
            </seminal_axis>
            <nodal_axis>
                <start_lag>1.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
            <nodal_axis>
                <start_lag>3.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
            <nodal_axis>
                <start_lag>4.0</start_lag>
                <probability>0.0</probability>
            </nodal_axis>
        </plant>
    </construction>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}
