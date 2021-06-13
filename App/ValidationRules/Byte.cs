using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class Byte : ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var canConvert = byte.TryParse(value as string, out byte result);
      return new ValidationResult(canConvert, "Must be between 0 and 255 inclusive.");
    }
  }
}
