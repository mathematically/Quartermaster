using System;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ClipboardItemTextSource : IItemTextSource, IDisposable
    {
        private readonly IClipboardMonitor _clipboardMonitor;

        public ClipboardItemTextSource(IClipboardMonitor clipboardMonitor)
        {
            _clipboardMonitor = clipboardMonitor;
            _clipboardMonitor.ClipboardTextArrived += OnClipboardTextArrived;
        }

        private void OnClipboardTextArrived(object sender, ClipboardChangedEventArgs args)
        {
            OnItemTextArrived(new GameItemChangedEventArgs(args.GameItemText));
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