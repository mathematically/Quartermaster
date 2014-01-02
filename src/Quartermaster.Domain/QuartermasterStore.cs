using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
    public class QuartermasterStore : IQuartermaster
    {
        private readonly IPoeItemFactory _itemFactory;
        private readonly IItemTextSource _itemTextSource;

        EmptyPoeItem _blankItem = new EmptyPoeItem();
        EmptyPoeWeapon _blankWeapon = new EmptyPoeWeapon();
        
        private IPoeItem _item;
        private IPoeWeapon _weapon;

        public IPoeItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public IPoeWeapon Weapon
        {
            get { return _weapon; }
            private set { _weapon = value; }
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
            else
            {
                _item = _blankItem;
                _weapon = _blankWeapon;
            }
        }

        private void CreatePoeItem(string itemText)
        {
            _item = _itemFactory.CreateItem(itemText);

            if (_item is PoeWeapon)
            {
                _weapon = _item as PoeWeapon;
            }
            else
            {
                _weapon = _blankWeapon;
            }
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

            OnPoeItemArrived(new PoeItemEventArgs(_item));
        }

        public void Dispose()
        {
            _itemTextSource.ItemTextArrived -= ItemTextSourceOnItemTextArrived;
        }
    }
}