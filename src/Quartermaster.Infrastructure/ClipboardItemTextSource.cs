using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ClipboardItemTextSource : IItemTextSource, IDisposable
    {
        private readonly IClipboardMonitor _clipboardMonitor;
        private readonly IItemTextChecker _itemTextChecker;

        public string ItemText
        {
            get; private set;
        }

        public bool HasItemText()
        {
            return !string.IsNullOrEmpty(ItemText);
        }

        public ClipboardItemTextSource(IClipboardMonitor clipboardMonitor, IItemTextChecker itemTextChecker)
        {
            _clipboardMonitor = clipboardMonitor;
            _itemTextChecker = itemTextChecker;

            TryLoadGameTest(clipboardMonitor.CurrentText);

            _clipboardMonitor.ClipboardTextArrived += OnClipboardTextArrived;
        }

        private bool TryLoadGameTest(string currentClipboardText)
        {
            if (_itemTextChecker.LooksLikeGameText(currentClipboardText))
            {
                ItemText = currentClipboardText;
                return true;
            }

            return false;
        }

        private void OnClipboardTextArrived(object sender, ClipboardChangedEventArgs args)
        {
            var clipboardText = args.GameItemText;

            TryLoadGameTest(clipboardText);
            if (TryLoadGameTest(clipboardText))
            {
                OnItemTextArrived(new GameItemChangedEventArgs(clipboardText));
            }
        }

        public event EventHandler<GameItemChangedEventArgs> ItemTextArrived;

        private void OnItemTextArrived(GameItemChangedEventArgs e)
        {
            EventHandler<GameItemChangedEventArgs> handler = ItemTextArrived;
            if (handler != null) handler(this, e);
        }

        public void Dispose()
        {
            _clipboardMonitor.ClipboardTextArrived -= OnClipboardTextArrived;
            _clipboardMonitor.Dispose();
        }
    }
}