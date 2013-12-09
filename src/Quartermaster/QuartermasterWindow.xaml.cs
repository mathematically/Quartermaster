using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.ViewModel;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster
{
    /// <summary>
    /// Interaction logic for QuartermasterWindow.xaml
    /// </summary>
    public partial class QuartermasterWindow : Window
    {
        private QuartermasterViewModel _quartermasterViewModel;

        public QuartermasterWindow()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Closed += OnClosed;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var windowInteropHelper = new WindowInteropHelper(this);
            var hWnd = windowInteropHelper.Handle;

            var hwndSource = (HwndSource)HwndSource.FromVisual(this);

            var clipboardMonitor = new ClipboardMonitor(hWnd, hwndSource);
            var clipboardItemTextSource = new ClipboardItemTextSource(clipboardMonitor);
            var quartermaster = new QuartermasterStore(clipboardItemTextSource);

            _quartermasterViewModel = new QuartermasterViewModel(quartermaster);

            DataContext = _quartermasterViewModel;
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            this.Closed -= OnClosed;
            this.Loaded -= OnLoaded;

            _quartermasterViewModel.Dispose();
        }
    }
}
