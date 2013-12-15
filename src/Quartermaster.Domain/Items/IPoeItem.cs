namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItem
    {
        string Name { get; }
        ItemRarity Rarity { get; }
    }
}