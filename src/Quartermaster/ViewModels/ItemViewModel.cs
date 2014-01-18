using System;
using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.ViewModels
{
    public class ItemViewModel : Screen, IDisposable
    {
        private readonly IQuartermaster _quartermaster;
        private IPoeItem _item;

        protected ItemViewModel(IQuartermaster quartermaster)
        {
            _quartermaster = quartermaster;

            Item = _quartermaster.Item;

            _quartermaster.PoeItemArrived += _quartermaster_PoeItemArrived;
        }

        void _quartermaster_PoeItemArrived(object sender, PoeItemEventArgs e)
        {
            Item = _quartermaster.Item;
        }

        public IPoeItem Item
        {
            get { return _item; }
            private set
            {
                _item = value;
                NotifyOfPropertyChange(() => Item);
            }
        }

        public void Dispose( )
        {
            _quartermaster.PoeItemArrived -= _quartermaster_PoeItemArrived;
        }
    }
}