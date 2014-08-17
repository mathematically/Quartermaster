using System.ComponentModel;

namespace Mathematically.Quartermaster.Domain.Items
{
    public interface ICommonPoeItemData
    {
        string Name { get; }
        ItemRarity Rarity { get; }
        int ItemLevel { get; }
        //ItemType ItemType { get; }
    }
    
    public enum ItemType
    {
        [Description("One Handed Axe")] OneHandedAxe,
        [Description("Two Handed Axe")] TwoHandedAxe,
    }

    public enum BaseType
    {
        RustedHatchet,
    }

    //static Dictionary<BaseType, ItemType> TypeCompendium;

}

