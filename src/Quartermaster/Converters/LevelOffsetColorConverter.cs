using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Converters
{
    public class LevelOffsetColorConverter : IValueConverter
    {
        private readonly SolidColorBrush _epicBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#af6025"));
        private readonly SolidColorBrush _rareBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffff77"));
        private readonly SolidColorBrush _magicBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8888ff"));
        private readonly SolidColorBrush _normalBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#c8c8c8"));

        public LevelOffsetColorConverter()
        {
            _epicBrush.Freeze();
            _rareBrush.Freeze();
            _magicBrush.Freeze();
            _normalBrush.Freeze();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = ((ItemMod) value).Offset;

            if (offset == 0)
                return _epicBrush;

            if (offset == 1)
                return _rareBrush;

            if (offset == 2)
                return _magicBrush;

            return _normalBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}