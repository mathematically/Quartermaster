namespace Mathematically.Quartermaster.Domain.Items
{
    public class ElementalDamage : IElementalDamage
    {
        private readonly int _maxLightningDamage;
        private readonly int _minFireDamage;
        private readonly int _maxFireDamage;
        private readonly int _minColdDamage;
        private readonly int _maxColdDamage;
        private readonly int _minLightningDamage;

        public virtual int MinFireDamage
        {
            get { return _minFireDamage; }
        }

        public virtual int MaxFireDamage
        {
            get { return _maxFireDamage; }
        }

        public virtual int MinColdDamage
        {
            get { return _minColdDamage; }
        }

        public virtual int MaxColdDamage
        {
            get { return _maxColdDamage; }
        }

        public virtual int MinLightningDamage
        {
            get { return _minLightningDamage; }
        }

        public virtual int MaxLightningDamage
        {
            get { return _maxLightningDamage; }
        }

        public ElementalDamage(int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage)
        {
            _minFireDamage = minFireDamage;
            _maxFireDamage = maxFireDamage;
            _minColdDamage = minColdDamage;
            _maxColdDamage = maxColdDamage;
            _minLightningDamage = minLightningDamage;
            _maxLightningDamage = maxLightningDamage;
        }

        protected ElementalDamage( )
        {
        }
    }
}