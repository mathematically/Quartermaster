namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IElementalDamage
    {
        int MinFireDamage { get; }
        int MaxFireDamage { get; }
        int MinColdDamage { get; }
        int MaxColdDamage { get; }
        int MinLightningDamage { get; }
        int MaxLightningDamage { get; }
    }
}