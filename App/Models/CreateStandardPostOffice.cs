﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardPostOffice : ICreate, ICreateStandard<PostOffice.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/PostOfficeSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/PostOfficeSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/PostOffice.xsd"">
    <construction>
        <owner>PostOffice</owner>
        <postoffice>
            <random_seed>1234567890</random_seed>
            <previous>1990,1,1,9,0,0</previous>
            <now>1990,1,1,9,0,0</now>
            <next_start>1990,1,1,9,0,0</next_start>
            <next_end>1990,1,5,0,0,0</next_end>
            <defaultruntime>0,0,35,0,0,0</defaultruntime>
        </postoffice>
    </construction>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}
