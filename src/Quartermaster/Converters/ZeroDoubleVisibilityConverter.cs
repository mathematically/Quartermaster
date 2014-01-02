using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mathematically.Quartermaster.Converters
{
    public class ZeroDoubleVisibilityConverter : IValueConverter
    {
        public Visibility IsZero { get; set; }
        public Visibility IsNotZero { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double) value == 0.0 ? IsZero : IsNotZero;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}