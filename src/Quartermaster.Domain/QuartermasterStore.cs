using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class QuartermasterStore : IQuartermaster
    {
        private readonly IItemTextSource _itemTextSource;
        private IPoeItem _item = new EmptyPoeItem();

        public IPoeItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public event EventHandler<PoeItemEventArgs> PoeItemArrived;

        protected virtual void OnPoeItemArrived(PoeItemEventArgs e)
        {
            EventHandler<PoeItemEventArgs> handler = PoeItemArrived;
            if (handler != null) handler(this, e);
        }

        public QuartermasterStore(IItemTextSource itemTextSource)
        {
            _itemTextSource = itemTextSource;
            _itemTextSource.ItemTextArrived += ItemTextSourceOnItemTextArrived;
        }

        private void ItemTextSourceOnItemTextArrived(object sender, GameItemChangedEventArgs args)
        {
            _item = new PoeItem("Iron Ring", ItemRarity.Normal);

            OnPoeItemArrived(new PoeItemEventArgs(_item));
        }

        public void Dispose()
        {
            _itemTextSource.ItemTextArrived -= ItemTextSourceOnItemTextArrived;
        }
    }
}