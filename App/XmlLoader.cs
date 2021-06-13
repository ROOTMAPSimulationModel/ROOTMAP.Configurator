using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;
using Rootmap.Configurator.Schema;

namespace Rootmap.Configurator
{
  public class XmlLoader : ILoader
  {
    public dynamic OpenOrCreate(string path, string schemaName, string configurationName)
    {
      try
      {
        var content = File.ReadAllText(path);
        return Deserialise(content, path);
        throw new ArgumentException($"Could not create an instance of a ROOTMAP configuration type from path {path}.");
      }
      catch (FileNotFoundException)
      { }
      catch (DirectoryNotFoundException)
      {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
      }
      return CreateStandardInstance(schemaName, configurationName);
    }

    public dynamic Deserialise(string serialisedContent) => Deserialise(serialisedContent, null);

    private dynamic Deserialise(string serialisedContent, string path)
    {
      using (StringReader stringReader = new StringReader(serialisedContent))
      using (XmlReader xmlReader = XmlReader.Create(stringReader))
      {
        var extractedSchemaName = ExtractSchemaName(serialisedContent, path);
        var schemaType = GetTypeForSchema(extractedSchemaName);
        var serialiser = new XmlSerializer(schemaType);
        if (serialiser.CanDeserialize(xmlReader))
        {
          dynamic result = serialiser.Deserialize(xmlReader);
          return result
              ?? Activator.CreateInstance(schemaType);
        }
      }
      throw new InvalidOperationException("Cannot deserialise object from this content: " + serialisedContent);
    }

    private dynamic CreateStandardInstance(string schemaName, string configurationName)
    {
      var filteredConfigurationName = Regex.Replace(configurationName, @"[^a-zA-Z0-9]", string.Empty);
      var mainType = GetTypeForSchema(schemaName);
      string baseNamespace = $"{nameof(Rootmap)}.{nameof(Rootmap.Configurator)}.{nameof(Rootmap.Configurator.Schema)}";
      var standardCreatorType = GetTypesInPartialNamespace(baseNamespace)
          .SingleOrDefault(t => typeof(ICreate).IsAssignableFrom(t)
              && t.Name.Contains(filteredConfigurationName)
              && t.GetInterfaces().Any(i => i.IsGenericType
                  && i.GetGenericTypeDefinition() == typeof(ICreateStandard<>)
                  && i.GetGenericArguments().Any(ga => ga.FullName == $"{baseNamespace}.{schemaName}.rootmap")));
      if (standardCreatorType != null)
      {
        return ((ICreate)Activator.CreateInstance(standardCreatorType)).Create(this);
      }
      // This is likely to be a coding error, if it occurs.
      throw new ApplicationException($"No ICreateStandard<> implementation found for type {mainType.FullName} (schema name {schemaName}). Could not create an instance.");
    }

    private Type GetTypeForSchema(string schemaName)
    {
      string baseNamespace = $"{nameof(Rootmap)}.{nameof(Rootmap.Configurator)}.{nameof(Rootmap.Configurator.Schema)}";
      var schemaType = GetTypesInPartialNamespace(baseNamespace)
          .SingleOrDefault(x => x.FullName == $"{baseNamespace}.{schemaName}.rootmap");
      return schemaType;
    }

    private string ExtractSchemaName(string xmlFileContent, string path = null)
    {
      var matcher = Regex.Match(xmlFileContent, "rootmap-schemata-container/(.*?).xsd");
      if (matcher.Groups.Count != 2)
      {
        throw new RootmapConfigurationException(path == null
            ? $"Text content does not contain a schema reference."
            : $"File {path} does not contain a schema reference.");
      }
      var schemaName = matcher.Groups[1].Value;
      return schemaName;
    }

    private Type[] GetTypesInPartialNamespace(string partialNamespace)
    {
      return Assembly.GetExecutingAssembly().GetTypes()
          .Where(t => t.IsPublic)
          .Where(t => t.Namespace != null
              && t.Namespace.StartsWith(partialNamespace, StringComparison.Ordinal))
          .ToArray();
    }
  }
}
