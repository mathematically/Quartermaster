using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
    public class QuartermasterStore : IQuartermaster, IDisposable
    {
        private readonly IItemTextSource _itemTextSource;
        private IPoeItem _item = new EmptyPoeItem();

        public IPoeItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public QuartermasterStore(IItemTextSource itemTextSource)
        {
            _itemTextSource = itemTextSource;
            _itemTextSource.ItemTextArrived += ItemTextSourceOnItemTextArrived;
        }

        private void ItemTextSourceOnItemTextArrived(object sender, GameItemChangedEventArgs args)
        {
            _item = new PoeItem("Iron Ring", ItemRarity.Normal);
        }

        public void Dispose()
        {
            _itemTextSource.ItemTextArrived -= ItemTextSourceOnItemTextArrived;
        }
    }
}