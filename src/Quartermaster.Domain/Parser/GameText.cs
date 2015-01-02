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
                .Where(t => _textLines[t] == PoeText.SECTION_DIVIDER).ToList();
        }

        public string Text
        {
            get { return _itemText; }
        }

        public string this[int i]
        {
            get { return _textLines[i]; }
        }

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

        public string BaseItemText()
        {
            // Note the need to differentiate the following two cases:

            // Rarity: Magic
            // Thirsty Ruby Ring of Success
            // --------

            // Rarity: Rare
            // Horror Medallion
            // Jade Amulet
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
                // All the text after the last divider (unless it's an epic which will have flavour text)
                return _textLines.Skip(_dividerIndexes.Last() + 1);
            }
        }
    }
}