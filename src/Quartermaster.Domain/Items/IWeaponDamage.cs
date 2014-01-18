namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IWeaponDamage
    {
        int MinPhysical { get; }
        int MaxPhysical { get; }
        int MinFireDamage { get; }
        int MaxFireDamage { get; }
        int MinColdDamage { get; }
        int MaxColdDamage { get; }
        int MinLightningDamage { get; }
        int MaxLightningDamage { get; }

        double AttackSpeed { get; }

        double DPS { get; }
        double PhysicalDPS { get; }
        double ElementalDPS { get; }
    }
}