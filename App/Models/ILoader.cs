namespace Rootmap.Configurator.Schema
{
  public interface ILoader
  {
    dynamic OpenOrCreate(string path, string schemaName, string configurationName);
    dynamic Deserialise(string serialisedContent);
  }
}
