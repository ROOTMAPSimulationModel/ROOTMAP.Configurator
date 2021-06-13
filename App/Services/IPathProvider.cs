namespace Rootmap.Configurator.Services
{
  public interface IPathProvider
  {
    string CliRootmap { get; }
    string GuiRootmap { get; }
  }
}
