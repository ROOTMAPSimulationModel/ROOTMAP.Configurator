using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class PositionArray : ValidationRule
  {
    private const string PositionArrayRegex = @"^(\s*([0-9]+,)*[0-9]+\s*\n?)+$";
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var valid = Regex.IsMatch(value as string, PositionArrayRegex, RegexOptions.Singleline);
      return new ValidationResult(valid, "Must be rows of comma-separated integers.");
    }
  }
}
