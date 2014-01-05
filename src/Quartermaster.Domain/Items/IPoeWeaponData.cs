namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeWeaponData
    {
        int MinPhysicalDamage { get; }
        int MaxPhysicalDamage { get; }
        double AttackSpeed { get; }
        IElementalDamage Elemental { get; }
    }
}