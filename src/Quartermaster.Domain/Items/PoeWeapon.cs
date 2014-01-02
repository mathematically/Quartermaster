namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeWeapon : PoeItem, IPoeWeapon
    {
        public double DPS
        {
            get { return 123.4; }
        }

        public PoeWeapon(string name, ItemRarity rarity, int itemLevel) : base(name, rarity, itemLevel)
        {
        }
    }
}