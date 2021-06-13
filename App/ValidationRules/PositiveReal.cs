using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class PositiveReal : ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var canConvert = double.TryParse(value as string, out double result);
      var valid = canConvert && result >= 0;
      return new ValidationResult(valid, "Must be a positive number.");
    }
  }
}
