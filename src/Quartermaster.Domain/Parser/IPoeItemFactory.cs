using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IPoeItemFactory
    {
        IPoeItem CreateItem(string gameItemText);
    }
}