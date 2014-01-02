namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemFactory : IPoeItemFactory
    {
        private readonly IPoeItemParser _itemParser;

        public PoeItemFactory(IPoeItemParser itemParser)
        {
            _itemParser = itemParser;
        }

        public IPoeItem CreateItem(string gameItemText)
        {
            _itemParser.Parse(gameItemText);

            return _itemParser.IsWeapon
                ? new PoeWeapon(_itemParser.Name, _itemParser.Rarity, _itemParser.ItemLevel)
                : new PoeItem(_itemParser.Name, _itemParser.Rarity, _itemParser.ItemLevel);
        }
    }
}