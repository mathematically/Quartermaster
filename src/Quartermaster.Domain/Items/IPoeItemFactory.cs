namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IPoeItemFactory
    {
        IPoeItem CreateItem(string gameItemText);
    }
}