using System.Xml.Serialization;

namespace Rootmap.Configurator.Schema.Main
{
  public partial class rootmap
  {
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Schema = @"https://example.org/ROOTMAP/MainSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/Main.xsd";
  }
}
