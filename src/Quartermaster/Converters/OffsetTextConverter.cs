using System;
using System.Globalization;
using System.Windows.Data;

namespace Mathematically.Quartermaster.Converters
{
    public class OffsetTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = (int)value;

            if (offset == 0)
                return "UNIQUE";
            if (offset == 1)
                return "RARE";
            if (offset == 0)
                return "MAGIC";

            return "NORMAL";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}