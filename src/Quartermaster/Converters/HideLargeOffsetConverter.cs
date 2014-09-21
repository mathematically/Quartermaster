using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mathematically.Quartermaster.Converters
{
    public class HideLargeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = (int)value;
            return offset <= 3 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}