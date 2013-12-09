using System;

namespace Mathematically.Quartermaster.Domain
{
    public class GameItemChangedEventArgs : EventArgs
    {
        public string ItemText { get; private set; }

        public GameItemChangedEventArgs(string itemText)
        {
            ItemText = itemText;
        }
    }
}