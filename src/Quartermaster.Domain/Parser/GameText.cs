using System;
using System.Collections.Generic;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class GameText
    {
        private const int BaseItemTypeIndex = 2;

        private readonly string _itemText;
        private readonly string[] _textLines;
        private readonly List<int> _dividerIndexes;

        public GameText(string itemText)
        {
            _itemText = itemText;
            _textLines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);
            _dividerIndexes = Enumerable.Range(0, _textLines.Count())
                .Where(t => _textLines[t] == TooltipText.SECTION_DIVIDER).ToList();
        }

        public string Text => _itemText;

        public string this[int i] => _textLines[i];

        public string LineWith(string label)
        {
            return _textLines.First(line => line.Contains(label));
        }

        public bool Contains(string label)
        {
            return OptionalLineWith(label) != null;
        }

        public string OptionalLineWith(string label)
        {
            return _textLines.FirstOrDefault(line => line.Contains(label));
        }

        public bool HasOptionalLineWith(string label)
        {
            return OptionalLineWith(label) != null;
        }

        public string BaseItemText()
        {
            // Note the need to differentiate the following two cases:

            // Rarity: Magic
            // Thirsty Ruby Ring of Success
            // --------

            // Rarity: Rare
            // Horror Medallion
            // Jade Amulets
            // --------

            var adjustment = HasName() ? 0 : 1;
            return _textLines[BaseItemTypeIndex - adjustment];
        }

        public bool HasName()
        {
            return _dividerIndexes.First() != 2;
        }

        public IEnumerable<string> ModText
        {
            get
            {
                // Mods section is always the one after ItemLevel.  Which will be the last section unless
                // it's an epic (flavour text) or has MTX ("Has FancyGlow")
                // ???? What about implicit mods which may or may not be there and have an extra marker?
                var itemLevelSearch = _textLines.Select((value, index) => new {Value = value, Index = index})
                    .Single(p => p.Value.StartsWith(TooltipText.ITEMLEVEL_LABEL));

                var hasMtx = _textLines.Any(t => t.StartsWith(TooltipText.MTX_MARKER));
                var isEpic = _textLines.Any(t => t.Contains(TooltipText.RARITY_LABEL + "Epic"));

                // todo write tests and fix this properly. 
                return _textLines.Skip(itemLevelSearch.Index + 2)
                    .TakeWhile(text => !text.Contains(TooltipText.MTX_MARKER));
            }
        }
    }
}