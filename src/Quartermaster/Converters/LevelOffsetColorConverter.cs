using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Converters
{
    public class LevelOffsetColorConverter : IValueConverter
    {
        private SolidColorBrush epicBrush = new SolidColorBrush(Colors.OrangeRed);
        private SolidColorBrush rareBrish = new SolidColorBrush(Colors.Yellow);
        private SolidColorBrush magicBrush = new SolidColorBrush(Colors.RoyalBlue);
        private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);

        public LevelOffsetColorConverter()
        {
            epicBrush.Freeze();
            rareBrish.Freeze();
            magicBrush.Freeze();
            normalBrush.Freeze();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = ((ItemMod) value).Offset;

            if (offset == 0)
                return epicBrush;

            if (offset == 1)
                return rareBrish;

            if (offset == 2)
                return magicBrush;

            return normalBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}