using System;

namespace Rootmap.Configurator
{
  public class RootmapConfigurationException : Exception
  {
    public RootmapConfigurationException()
    { }

    public RootmapConfigurationException(string message) : base(message)
    { }

    public RootmapConfigurationException(string message, Exception innerException) : base(message, innerException)
    { }
  }
}
