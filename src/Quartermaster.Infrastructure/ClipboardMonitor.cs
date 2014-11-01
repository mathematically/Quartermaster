using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Quartermaster.Infrastructure
{
    /// <summary>
    ///     Listens for clipboard changes and raises ClipboardTextArrived event.
    /// </summary>
    public class ClipboardMonitor : IClipboardMonitor
    {
        #region PInvokes

        // Note these were new in Vista so this means XP won't work.

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool AddClipboardFormatListener(IntPtr hWndListener);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hWndListener);

        private const int WM_CLIPBOARDUPDATE = 0x031D;

        #endregion

        private IntPtr _hWnd;
        private HwndSource _source;

        public string CurrentText { get; private set; }

        public ClipboardMonitor()
        {
            if (Clipboard.ContainsText())
            {
                CurrentText = Clipboard.GetText();
            }
        }

        public void BindToVisual(IntPtr hWnd, HwndSource source)
        {
            _hWnd = hWnd;
            _source = source;

            _source.AddHook(WndProc);
            AddClipboardFormatListener(_hWnd);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Only interested in clipboard updates.
            if (msg != WM_CLIPBOARDUPDATE) return IntPtr.Zero;

            // and then only updates that contain text.
            if (Clipboard.ContainsText())
            {
                OnClipboardTextArrived(new ClipboardChangedEventArgs(Clipboard.GetText()));
            }

            return IntPtr.Zero;
        }

        public event EventHandler<ClipboardChangedEventArgs> ClipboardTextArrived;

        private void OnClipboardTextArrived(ClipboardChangedEventArgs e)
        {
            var handler = ClipboardTextArrived;
            if (handler != null) handler(this, e);
        }

        public void Dispose()
        {
            RemoveClipboardFormatListener(_hWnd);
            _source.RemoveHook(WndProc);
        }
    }
}