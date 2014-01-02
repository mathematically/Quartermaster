namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        private readonly string _name;
        private readonly ItemRarity _rarity;
        private readonly int _itemLevel;

        public virtual string Name
        {
            get { return _name; }
        }

        public virtual ItemRarity Rarity
        {
            get { return _rarity; }
        }

        public virtual int ItemLevel
        {
            get { return _itemLevel; }
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel)
        {
            _name = name;
            _rarity = rarity;
            _itemLevel = itemLevel;
        }

        public PoeItem(IPoeItemData itemData)
        {
            _name = itemData.Name;
            _rarity = itemData.Rarity;
            _itemLevel = itemData.ItemLevel;
        }

        protected PoeItem()
        {
        }
    }
}