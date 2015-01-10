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

            switch (offset)
            {
                case 0:
                    return "UNIQUE";
                case 1:
                    return "RARE";
                case 2:
                    return "MAGIC";
            }

            return offset;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}