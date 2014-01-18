namespace Mathematically.Quartermaster.Domain.Items
{
    public class ElementalDamage : IElementalDamage
    {
        public virtual int MinFireDamage { get; private set; }
        public virtual int MaxFireDamage { get; private set; }
        public virtual int MinColdDamage { get; private set; }
        public virtual int MaxColdDamage { get; private set; }
        public virtual int MinLightningDamage { get; private set; }
        public virtual int MaxLightningDamage { get; private set; }

        public ElementalDamage(int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage)
        {
            MinFireDamage = minFireDamage;
            MaxFireDamage = maxFireDamage;
            MinColdDamage = minColdDamage;
            MaxColdDamage = maxColdDamage;
            MinLightningDamage = minLightningDamage;
            MaxLightningDamage = maxLightningDamage;
        }

        protected ElementalDamage( )
        {
        }
    }
}