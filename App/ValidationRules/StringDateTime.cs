using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  public class StringDateTime : ValidationRule
  {
    // Copied from the XSD regex.
    private const string StringDateTimeRegex = @"^[0-9]{1,4},[0-1]?[0-9],[0-3]?[0-9],[0-2]?[0-9](,[0-6]?[0-9]){2}$";
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var valid = Regex.IsMatch(value as string, StringDateTimeRegex, RegexOptions.Singleline);
      return new ValidationResult(valid, "Must be a date in the following numerical format: year,month,day,hour,minute,second");
    }
  }
}
