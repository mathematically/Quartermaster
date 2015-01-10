using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Converters
{
    public class LevelOffsetColorConverter : IValueConverter
    {
        private readonly SolidColorBrush _epicBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#af6025"));
        private readonly SolidColorBrush _rareBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffff77"));
        private readonly SolidColorBrush _magicBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8888ff"));
        private readonly SolidColorBrush _normalBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffffff"));
        private readonly SolidColorBrush _junkBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#777777"));

        public LevelOffsetColorConverter()
        {
            _epicBrush.Freeze();
            _rareBrush.Freeze();
            _magicBrush.Freeze();
            _normalBrush.Freeze();
            _junkBrush.Freeze();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = ((ItemMod) value).Offset;

            switch (offset)
            {
                case 0:
                    return _epicBrush;
                case 1:
                    return _rareBrush;
                case 2:
                    return _magicBrush;

                case 3:
                case 4:
                    return _normalBrush;

            }

            return _junkBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}