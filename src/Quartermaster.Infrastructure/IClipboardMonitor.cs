using System;
using System.Windows.Interop;

namespace Quartermaster.Infrastructure
{
    public interface IClipboardMonitor : IDisposable
    {
        string CurrentText { get; }
        event EventHandler<ClipboardChangedEventArgs> ClipboardTextArrived;
        void BindToVisual(IntPtr hWnd, HwndSource source);
    }
}