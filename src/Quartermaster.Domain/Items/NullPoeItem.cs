namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    /// A PoeItem null object.
    /// </summary>
    public class NullPoeItem : PoeItem
    {
        public override string Name
        {
            get { return string.Empty; }
        }

        public override ItemRarity Rarity
        {
            get { return ItemRarity.Normal; }
        }

        public override int ItemLevel
        {
            get { return 1; }
        }

        public override int MinPhysicalDamage
        {
            get { return 0; }
        }

        public override int MaxPhysicalDamage
        {
            get { return 0; }
        }

        public override double AttackSpeed
        {
            get { return 0.0; }
        }

        public override double DPS
        {
            get { return 0.0; }
        }
    }
}