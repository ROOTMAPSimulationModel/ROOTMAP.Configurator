using System;
namespace Rootmap.Configurator.Schema
{
  // TODO find a better way to access this information.
  // This is a bit of a god class.
  // Maybe add 'schema name' properties to all the Model partials,
  // and use reflection to find the appropriate Model
  // by elementName at runtime.
  //
  public static class SchemaNames
  {
    public static string GetSchemaName(string elementName)
    {
      switch (elementName)
      {
        case "Scoreboard Boundaries":
          return "Scoreboards";
        case "Volume Objects":
          return "VolumeObjects";
        case "Plant Attributes":
        case "Nitrate Attributes":
        case "Phosphorus Attributes":
        case "Water Attributes":
          return "SharedAttributes";
        case "Post Office":
          return "PostOffice";
        case "Plant Types":
          return "PlantTypes";
        case "Plants":
          return "Plants";
        case "Processes":
          return "Processes";
        case "Plant Initial Values":
        case "Nitrate Initial Values":
        case "Phosphorus Initial Values":
        case "Water Initial Values":
        case "Phosphorus Initial Data":
        case "Nitrate Initial Data":
        case "Nitrate Initialisation Data":
        case "Bulk Density Initial Data":
        case "Bulk Density Initialisation":
        case "Water Initial Data":
        case "Water Initialisation Data":
          return "ScoreboardData";
        case "Water Rainfall Initial Data":
        case "Water Rainfall Initialisation":
          return "RainfallEvents";
        case "Output Rules":
          return "OutputRules";
        case "Renderer Configuration":
          return "Renderer";
        // Important note about "Tables", "Views" and "View3D":
        // they all write to the same file.
        case "Tables":
        case "Views":
        case "View3D":
          return "Windows";
        default:
          break;
      }
      throw new ArgumentException($"No known schema for ROOTMAP element name {elementName}.");
    }
  }
}
