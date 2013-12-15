using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Mathematically.Quartermaster.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumType = value.GetType();
            string result = Enum.GetName(enumType, value);

            var fieldInfo = enumType.GetField(result);
            var attributeArray = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributeArray.Length > 0 ? ((DescriptionAttribute)attributeArray[0]).Description : result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}