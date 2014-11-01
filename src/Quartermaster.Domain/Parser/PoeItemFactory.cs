using System;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using NLog;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemFactory : IPoeItemFactory
    {
        private readonly IAffixCompendium _compendium;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public PoeItemFactory(IAffixCompendium compendium)
        {
            _compendium = compendium;
        }

        public IPoeItem CreateItem(string gameItemText)
        {
            var itemParser = new PoeItemParser(_compendium, gameItemText);

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