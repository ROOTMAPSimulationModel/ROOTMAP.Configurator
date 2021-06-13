using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class ReasonableTemperature : ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var canConvert = double.TryParse(value as string, out double result);
      var valid = canConvert && result >= -49 && result <= 99;
      return new ValidationResult(valid, "Temperatures must be between -49 and 99 degrees Celsius inclusive.");
    }
  }
}
