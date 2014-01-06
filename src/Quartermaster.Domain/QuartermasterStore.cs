using System;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Parser;

namespace Mathematically.Quartermaster.Domain
{
    public class QuartermasterStore : IQuartermaster
    {
        private readonly IPoeItemFactory _itemFactory;
        private readonly IItemTextSource _itemTextSource;

        private IPoeItem _item = new NullPoeItem();

        public IPoeItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public QuartermasterStore(IPoeItemFactory itemFactory, IItemTextSource itemTextSource)
        {
            _itemFactory = itemFactory;
            _itemTextSource = itemTextSource;

            _itemTextSource.ItemTextArrived += ItemTextSourceOnItemTextArrived;

            if (_itemTextSource.HasItemText())
            {
                CreatePoeItem(_itemTextSource.ItemText);
            }
        }

        private void CreatePoeItem(string itemText)
        {
            Item = _itemFactory.CreateItem(itemText);
        }

        public event EventHandler<PoeItemEventArgs> PoeItemArrived;

        private void OnPoeItemArrived(PoeItemEventArgs e)
        {
            EventHandler<PoeItemEventArgs> handler = PoeItemArrived;
            if (handler != null) handler(this, e);
        }

        private void ItemTextSourceOnItemTextArrived(object sender, GameItemChangedEventArgs args)
        {
            CreatePoeItem(args.ItemText);

            OnPoeItemArrived(new PoeItemEventArgs(Item));
        }

        public void Dispose()
        {
            _itemTextSource.ItemTextArrived -= ItemTextSourceOnItemTextArrived;
        }
    }
}