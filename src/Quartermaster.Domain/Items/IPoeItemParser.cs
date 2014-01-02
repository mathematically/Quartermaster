namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItemParser: IPoeItem
    {
        void Parse(string itemText);
        bool IsWeapon { get; }
    }
}