using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class PositiveInteger : ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var canConvert = int.TryParse(value as string, out int result);
      var valid = canConvert && result >= 0;
      return new ValidationResult(valid, "Must be a positive integer.");
    }
  }
}
