using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mathematically.Quartermaster.Domain.Items;
using NLog;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class BaseItemParser
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        // This is full of entries like:
        //  BaseItemType.CrudeBow, { "Crude", "Bow" }
        // i.e. if we can find Crude and Bow in the tooltip text we think is the base item type, then this 
        // is the type in the key (e.g. CrudeBow).
        private static readonly Dictionary<BaseItemType, string[]> _lookup = new Dictionary<BaseItemType, string[]>();

        private void CreateBaseItemTypeWordLookup()
        {
            // Make sure we only do this once.
            if (_lookup.Any())
                return;

            var strings = Enum.GetNames(typeof (BaseItemType)).ToList();

            strings.ForEach(s =>
            {
                // todo this is a crap way of doing this with the replace and then split but my RegEx fu is crap today
                var wordSet = Regex.Replace(s, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ").Split(new[] {' '});
                _lookup.Add((BaseItemType)Enum.Parse(typeof(BaseItemType), s), wordSet);
            });
        }

        public BaseItemParser()
        {
            CreateBaseItemTypeWordLookup();
        }

        public BaseItemType Parse(GameText gameText)
        {
            var baseItemTypeText = gameText.BaseItemText().Replace(" ", string.Empty);

            // Simple parse will find "Ruby Ring", complex parse for things like "Thirsty Ruby Ring of Success"
            BaseItemType baseItemType;
            if (Enum.TryParse(baseItemTypeText, true, out baseItemType))
            {
                return baseItemType;
            }

            if (TryComplexParse(baseItemTypeText, out baseItemType))
            {
                return baseItemType;
            }

            Log.Error("Couldn't parse base item type of " + baseItemTypeText + " defaulting to CrudeBow");
            return BaseItemType.CrudeBow;
        }

        private bool TryComplexParse(string baseItemTypeText, out BaseItemType baseItemType)
        {
            // This is likely not going to be perfect.
            foreach (var map in _lookup.Where(map => map.Value.All(baseItemTypeText.Contains)))
            {
                baseItemType = map.Key;
                return true;
            }

            baseItemType = BaseItemType.CrudeBow;
            return false;
        }
    }
}