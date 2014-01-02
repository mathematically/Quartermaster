namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItemParser : IPoeUniversalItemData
    {
        void Parse(string itemText);
        bool IsWeapon { get; }
    }
}