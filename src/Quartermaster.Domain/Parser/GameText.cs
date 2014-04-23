using System;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class GameText
    {
        private readonly string _itemText;
        private readonly string[] _textLines;

        public GameText(string itemText)
        {
            _itemText = itemText;
            _textLines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);
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
    }
}