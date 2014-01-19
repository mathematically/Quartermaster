using System;
using Mathematically.Quartermaster.Domain.Parser;
using NLog;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemFactory : IPoeItemFactory
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly IPoeItemParser _itemParser;

        public PoeItemFactory(IPoeItemParser itemParser)
        {
            _itemParser = itemParser;
        }

        public IPoeItem CreateItem(string gameItemText)
        {
            try
            {
                _itemParser.Parse(gameItemText);
            }
            catch (Exception e)
            {
                Log.ErrorException("Failed to parse clipboard text " + gameItemText + " (" + e.Message + ")", e);
            }

            return new PoeItem(_itemParser);
        }
    }
}