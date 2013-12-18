﻿using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
    public class QuartermasterStore : IQuartermaster
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

            if (_itemTextSource.HasItemText())
            {
                CreatePoeItem(_itemTextSource.ItemText);
            }
        }

        private void CreatePoeItem(string itemText)
        {
            _item = new PoeItem("Iron Ring", ItemRarity.Normal);
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