namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeWeapon
    {
        double DPS { get; }
        IElementalDamage Elemental { get; }
    }
}