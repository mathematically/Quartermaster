using System;
using System.Globalization;
using System.Windows.Data;

namespace Mathematically.Quartermaster.Converters
{
    public class OffsetTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = (int) value;

            if (offset == 0)
                return "*";

            return offset <= 3 ? new string('-', offset) : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}