using System;
using Rootmap.Configurator.Services;

namespace Rootmap.Configurator
{
  public static class ChildControlFactory
  {
    private static readonly IViewModelCache _vmCache = SimpleIoC.Container.Resolve<IViewModelCache>();

    public static dynamic Create(dynamic dataModel, string modelFilename, string owner, int? index = null)
    {
      modelFilename = modelFilename.Replace('\\', '/');

      var existingVm = _vmCache.Get(modelFilename, owner, index); // May be null at this time.

      BaseCodeBehind control = null;

      switch (modelFilename)
      {
        case "OutputRules.xml":
          control = new OutputRule(dataModel, existingVm);
          break;
        case "PostOffice.xml":
          control = new PostOffice(dataModel, existingVm);
          break;
        case "Renderer.xml":
          control = new CharacteristicColourInfo(dataModel, existingVm);
          break;
        case "Scoreboards.xml":
          control = new Scoreboard(dataModel, existingVm);
          break;
        case "VolumeObjects.xml":
          control = new VolumeObject(dataModel, existingVm);
          break;
        case "Windows.xml":
          var modelOwnerString = dataModel.owner?.ToString();
          if (modelOwnerString != owner)
          {
            return null;
          }
          else
          {
            object t = dataModel.Item as Rootmap.Configurator.Schema.Windows.Table;
            object v = dataModel.Item as Rootmap.Configurator.Schema.Windows.View;
            object v3D = dataModel.Item as Rootmap.Configurator.Schema.Windows.View3D;

            if (t != null)
            {
              control = new Table(dataModel, existingVm);
            }
            else if (v != null)
            {
              control = new View(dataModel, existingVm);
            }
            else if (v3D != null)
            {
              control = new View3D(dataModel, existingVm);
            }
            else
            {
              throw new ArgumentException("Could not identify this data model as a Windows-schema visualisation", nameof(dataModel));
            }
          }
          break;
        case "process_data/Plants.xml":
          control = new Plant(dataModel, existingVm);
          break;
        case "process_data/PlantTypes.xml":
          control = new PlantType(dataModel, existingVm);
          break;
        case "process_data/Processes.xml":
          control = new Process(dataModel, existingVm);
          break;
        case "process_data/RainfallEvents.xml":
          control = new RainfallEvents(dataModel, existingVm);
          break;
        default:
          break;
      }
      if (control == null)
      {
        if (modelFilename.StartsWith("scoreboard_data/"))
        {
          control = new ScoreboardData(dataModel, existingVm);
        }
        else if (modelFilename.StartsWith("shared_attributes/"))
        {
          if (dataModel as Rootmap.Configurator.Schema.ScoreboardData.ScoreboardDataScoreboarddata != null)
          {
            control = new ScoreboardData(dataModel, existingVm);
          }
          else
          {
            control = new SharedAttribute(dataModel, existingVm);
          }
        }
        else
        {
          throw new ArgumentException($"No UI control available for {modelFilename}.");
        }
      }
      if (existingVm == null)
      {
        _vmCache.Put(modelFilename, owner, index, control.ViewModel);
      }
      return control;
    }
  }
}
