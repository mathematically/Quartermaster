using System;

namespace Quartermaster.Infrastructure
{
    public class ClipboardChangedEventArgs : EventArgs
    {
        public string GameItemText { get; private set; }

        public ClipboardChangedEventArgs(string gameItemText)
        {
            GameItemText = gameItemText;
        }
    }
}