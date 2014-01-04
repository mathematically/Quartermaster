namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItemParser : IPoeItemData
    {
        void Parse(string itemText);
        bool IsWeapon { get; }
    }
}