namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        private readonly string _name;
        private readonly ItemRarity _rarity;

        public virtual string Name
        {
            get { return _name; }
        }

        public virtual ItemRarity Rarity
        {
            get { return _rarity; }
        }

        public PoeItem(string name, ItemRarity rarity)
        {
            _name = name;
            _rarity = rarity;
        }

        protected PoeItem() {}
    }
}