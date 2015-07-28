namespace Mathematically.Quartermaster.Domain.Items
{
    public class NullWeaponDamage : WeaponDamage
    {
        public override int MinFireDamage => 0;

        public override int MaxFireDamage => 0;

        public override int MinColdDamage => 0;

        public override int MaxColdDamage => 0;

        public override int MinLightningDamage => 0;

        public override int MaxLightningDamage => 0;
    }
}