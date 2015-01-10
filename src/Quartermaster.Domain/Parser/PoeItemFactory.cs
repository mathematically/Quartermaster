using System;
using Mathematically.Quartermaster.Domain.Items;
using NLog;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemFactory : IPoeItemFactory
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly IModParserCollection _modParsers;
        private readonly IItemLexicon _itemLexicon;

        public PoeItemFactory(IItemLexicon itemLexicon, IModParserCollection modParsers)
        {
            _itemLexicon = itemLexicon;
            _modParsers = modParsers;
        }

        public IPoeItem CreateItem(string gameItemText)
        {
            var itemParser = new PoeItemParser(_itemLexicon, _modParsers, gameItemText);

            try
            {
                itemParser.Parse();
                Log.Info("Logged item from text " + gameItemText);
            }
            catch (Exception e)
            {
                Log.Error("Failed to parse clipboard text " + gameItemText + " (" + e.Message + ")", e);
            }

            return new PoeItem(itemParser);
        }
    }
}