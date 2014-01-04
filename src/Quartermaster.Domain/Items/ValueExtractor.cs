using System;
using System.Runtime.Remoting.Messaging;

namespace Mathematically.Quartermaster.Domain.Items
{
    internal class ValueExtractor
    {
        public string TextFrom(string rawTooltipLine)
        {
            var markerLength = CalculateMarkerLength(rawTooltipLine);
            var cookedToolTipline = RemoveAugmentedIfPresent(rawTooltipLine);

            return cookedToolTipline.Substring(markerLength, cookedToolTipline.Length - markerLength);
        }

        private string RemoveAugmentedIfPresent(string tooltipLine)
        {
            if (tooltipLine.Contains(PoeText.AUGMENTED_ANNOTATION))
            {
                tooltipLine = tooltipLine.Replace(PoeText.AUGMENTED_ANNOTATION, "");
            }

            return tooltipLine;
        }

        private int CalculateMarkerLength(string tooltipLine)
        {
            // e.g. "Itemlevel: 4"
            return tooltipLine.IndexOf(':') + 2;
        }

        public int IntegerFrom(string tooltipLine)
        {
            return int.Parse(TextFrom(tooltipLine));
        }

        public Tuple<int, int> IntegerRangeFrom(string tooltipLine)
        {
            string valueText = TextFrom(tooltipLine);

            var values = valueText.Split(new[] { PoeText.RANGE_DIVIDER }, StringSplitOptions.None);

            return new Tuple<int, int>(int.Parse(values[0]), int.Parse(values[1]));
        }

        public double DoubleFrom(string tooltipLine)
        {
            return double.Parse(TextFrom(tooltipLine));
        }
    }
}