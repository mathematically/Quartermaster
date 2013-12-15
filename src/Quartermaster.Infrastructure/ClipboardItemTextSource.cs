using System;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ClipboardItemTextSource : IItemTextSource, IDisposable
    {
        private readonly IClipboardMonitor _clipboardMonitor;
        private readonly IItemTextSanityCheck _itemTextSanityChecker;

        public ClipboardItemTextSource(IClipboardMonitor clipboardMonitor, IItemTextSanityCheck itemTextSanityChecker)
        {
            _clipboardMonitor = clipboardMonitor;
            _itemTextSanityChecker = itemTextSanityChecker;

            _clipboardMonitor.ClipboardTextArrived += OnClipboardTextArrived;
        }

        private void OnClipboardTextArrived(object sender, ClipboardChangedEventArgs args)
        {
            var gameItemText = args.GameItemText;

            if (_itemTextSanityChecker.LooksLikeGameText(gameItemText))
            {
                OnItemTextArrived(new GameItemChangedEventArgs(gameItemText));
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