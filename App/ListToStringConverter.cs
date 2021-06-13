using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace Rootmap.Configurator
{
  [ValueConversion(typeof(IList<string>), typeof(string))]
  public class ListToStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (targetType != typeof(string))
        throw new InvalidOperationException("The target must be a string");

      return string.Join(Environment.NewLine, ((List<string>)value).ToArray());
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}