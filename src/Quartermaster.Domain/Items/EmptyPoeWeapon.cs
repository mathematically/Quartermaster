namespace Mathematically.Quartermaster.Domain.Items
{
    public class EmptyPoeWeapon : PoeWeapon
    {
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