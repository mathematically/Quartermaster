namespace Mathematically.Quartermaster.Domain.Items
{
    public interface ICommonPoeItemData
    {
        string Name { get; }
        ItemRarity Rarity { get; }
        int ItemLevel { get; }
    }
}