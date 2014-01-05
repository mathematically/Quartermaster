using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Mathematically.Quartermaster.Domain.Items
{
    public enum ElementalType
    {
        Fire, Cold, Lightning
    }

    public struct Range
    {
        public int Min { get; set; }    
        public int Max { get; set; }
    }

    internal class PoeTextValueExtractor
    {
        public string TextFrom(string rawTooltipLine)
        {
            var markerLength = CalculateMarkerLength(rawTooltipLine);
            var cookedTooltipLine = RemoveAugmentedIfPresent(rawTooltipLine);

            return cookedTooltipLine.Substring(markerLength, cookedTooltipLine.Length - markerLength);
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

        public Range IntegerRangeFrom(string tooltipLine)
        {
            string valueText = TextFrom(tooltipLine);

            var values = valueText.Split(new[] { PoeText.RANGE_DIVIDER }, StringSplitOptions.None);

            return new Range
            {
                Min = int.Parse(values[0]), 
                Max = int.Parse(values[1])
            };
        }

        public List<Range> RangeSetFrom(string tooltipLine)
        {
            var ranges = new List<Range>();

            // e.g. "Elemental Damage: 27-46 (augmented), 7-12 (augmented), 4-53 (augmented)"
            var valueTexts = TextFrom(tooltipLine)
                .Replace(" ", "")
                .Split(',');

            valueTexts.ForEach(t =>
            {
                var v = t.Split(new[] {PoeText.RANGE_DIVIDER}, StringSplitOptions.None);
                ranges.Add(new Range {Min = int.Parse(v[0]), Max = int.Parse(v[1])});
            });

            return ranges;
        }

        public double DoubleFrom(string tooltipLine)
        {
            return double.Parse(TextFrom(tooltipLine));
        }
    }

}