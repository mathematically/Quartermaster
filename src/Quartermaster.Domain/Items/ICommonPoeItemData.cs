namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     The properties every item has regardless of type or level.
    /// </summary>
    public interface ICommonPoeItemData
    {
        string Name { get; }
        ItemRarity Rarity { get; }
        int ItemLevel { get; }
        BaseItemType BaseType { get; }
    }
}