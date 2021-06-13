using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Rootmap.Configurator.ValidationRules
{
  /// <summary>
  /// Defines a duration or timestamp in the same format as StringDateTime: year, month, day, hour, minute, second.
  /// Can be used for a timestamp, i.e. "time since T=0".
  /// Can be used for a duration, e.g. "every 6 hours".
  /// </summary>
  public class SortableDuration : ValidationRule
  {
    private const string SortableDurationRegex = @"^([0-9]+,){5}[0-9]+$";
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      var valid = Regex.IsMatch(value as string, SortableDurationRegex, RegexOptions.Singleline);
      return new ValidationResult(valid, "Must be a positive numerical duration/timestamp in the following format: years,months,days,minutes,seconds");
    }
  }
}
