using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IPoeItemParser : IPoeItemData
    {
        void Parse(string itemText);
        bool IsWeapon { get; }
    }
}