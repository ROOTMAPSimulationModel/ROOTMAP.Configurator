using System.Windows.Input;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Implementation borrowed from Mike Taulty's blog @
  /// https://mtaulty.com/2008/11/19/m_10900/
  /// </summary>
  public static class CustomCommands
  {
    static CustomCommands()
    {
      Exit = new RoutedCommand("Exit", typeof(CustomCommands));
      RunRootmap = new RoutedCommand("RunRootmap", typeof(CustomCommands));
    }

    public static RoutedCommand Exit { get; private set; }

    public static RoutedCommand RunRootmap { get; private set; }
  }
}
