using System;
using System.Diagnostics.CodeAnalysis;

namespace Rootmap.Configurator.Services
{
  public struct FieldIdentifier : IEquatable<FieldIdentifier>
  {
    public string ConfigurationName { get; }
    public Guid ViewModelId { get; }
    public string FieldName { get; }

    public FieldIdentifier(string configurationName, Guid vmId, string fieldName)
    {
      ConfigurationName = configurationName;
      ViewModelId = vmId;
      FieldName = fieldName;
    }

    public bool Equals([AllowNull] FieldIdentifier other) =>
      other.ConfigurationName == this.ConfigurationName
        && other.ViewModelId == this.ViewModelId
        && other.FieldName == this.FieldName;

    public override string ToString() => $"{ConfigurationName}|{ViewModelId}|{FieldName}";
  }
}
