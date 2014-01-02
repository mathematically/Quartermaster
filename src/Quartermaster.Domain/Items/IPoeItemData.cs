namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItemData
    {
        string Name { get; }
        ItemRarity Rarity { get; }
        int ItemLevel { get; }
    }
}