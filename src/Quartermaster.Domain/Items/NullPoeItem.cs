namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    /// A PoeItem null object.
    /// </summary>
    public class NullPoeItem : PoeItem
    {
        public override string Name => string.Empty;

        public override ItemRarity Rarity => ItemRarity.Normal;

        public override int ItemLevel => 1;
    }
}