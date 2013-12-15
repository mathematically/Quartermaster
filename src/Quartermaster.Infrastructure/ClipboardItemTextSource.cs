using System;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ClipboardItemTextSource : IItemTextSource, IDisposable
    {
        private const string RARITY_MARKER = "Rarity: ";
        private const string SECTION_DIVIDER = "--------";

        private readonly IClipboardMonitor _clipboardMonitor;

        public ClipboardItemTextSource(IClipboardMonitor clipboardMonitor)
        {
            _clipboardMonitor = clipboardMonitor;
            _clipboardMonitor.ClipboardTextArrived += OnClipboardTextArrived;
        }

        private void OnClipboardTextArrived(object sender, ClipboardChangedEventArgs args)
        {
            var arrivedText = args.GameItemText;

            if (IsPotentialGameText(arrivedText))
            {
                OnItemTextArrived(new GameItemChangedEventArgs(arrivedText));
            }
        }

        private static bool IsPotentialGameText(string arrivedText)
        {
            return !string.IsNullOrEmpty(arrivedText) && arrivedText.Contains(RARITY_MARKER) && arrivedText.Contains(SECTION_DIVIDER);
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