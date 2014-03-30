using System;
using Mathematically.Quartermaster.Domain.Items;
using NLog;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemFactory : IPoeItemFactory
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

//        private readonly IPoeItemParser _itemParser;
//
//        public PoeItemFactory(IPoeItemParser itemParser)
//        {
//            _itemParser = itemParser;
//        }

        public IPoeItem CreateItem(string gameItemText)
        {
            var itemParser = new PoeItemParser(gameItemText);

            try
            {
                itemParser.Parse();
                Log.Info("Logged item from text " + gameItemText);
            }
            catch (Exception e)
            {
                Log.ErrorException("Failed to parse clipboard text " + gameItemText + " (" + e.Message + ")", e);
            }

            return new PoeItem(itemParser);
        }
    }
}