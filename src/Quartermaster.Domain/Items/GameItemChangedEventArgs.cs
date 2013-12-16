using System;

namespace Mathematically.Quartermaster.Domain.Items
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