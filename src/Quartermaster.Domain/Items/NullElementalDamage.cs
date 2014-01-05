namespace Mathematically.Quartermaster.Domain.Items
{
    public class NullElementalDamage : ElementalDamage
    {
        public override int MinFireDamage
        {
            get { return 0; }
        }

        public override int MaxFireDamage
        {
            get { return 0; }
        }

        public override int MinColdDamage
        {
            get { return 0; }
        }

        public override int MaxColdDamage
        {
            get { return 0; }
        }

        public override int MinLightningDamage
        {
            get { return 0; }
        }

        public override int MaxLightningDamage
        {
            get { return 0; }
        }
    }
}