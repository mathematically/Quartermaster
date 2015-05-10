using System;
using System.Reflection;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class ExampleItemReflectionHelper
    {
        public static PoeItem GetItem(Object src, string itemName)
        {
            var fixedItemName = itemName.Replace(" ", string.Empty);
            var type = src.GetType();
            var fieldInfo = type.GetField(fixedItemName, BindingFlags.Public | BindingFlags.Static);

            return (PoeItem)fieldInfo.GetValue(src);
        }

        public static string GetItemText(Object src, string itemName)
        {
            var fixedItemName = itemName.Replace(" ", string.Empty);
            var type = src.GetType();
            var fieldInfo = type.GetField(fixedItemName + "Text", BindingFlags.Public | BindingFlags.Static);

            return fieldInfo.GetValue(src).ToString();
        }
    }
}