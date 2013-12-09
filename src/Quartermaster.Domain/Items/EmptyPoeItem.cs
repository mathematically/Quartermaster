namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    /// A PoeItem null object.
    /// </summary>
    public class EmptyPoeItem : PoeItem
    {
        public override string Name
        {
            get { return string.Empty; }
        }

        public override ItemRarity Rarity
        {
            get { return ItemRarity.Normal; }
        }
    }
}