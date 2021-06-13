using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class UnitInterval : ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var canConvert = double.TryParse(value as string, out double result);
      var valid = canConvert && result >= 0 && result <= 1;
      return new ValidationResult(valid, "Must be between 0 and 1 inclusive.");
    }
  }
}
