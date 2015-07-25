using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class ModParsers: IModParserCollection
    {
        private static readonly List<IModParser> ModParserCollection = new List<IModParser>();

        private readonly IItemLexicon _itemLexicon;
        private readonly IAffixCompendium _affixCompendium;

        public ModParsers(IItemLexicon itemLexicon, IAffixCompendium affixCompendium)
        {
            _itemLexicon = itemLexicon;
            _affixCompendium = affixCompendium;
        }

        public IEnumerable<IModParser> All
        {
            get
            {
                BuildCollectionIfRequired();
                return ModParserCollection;
            }
        }

        private void BuildCollectionIfRequired()
        {
            if (ModParserCollection.Any())
                return;

            // The order of these determines the order of the mods on the parsed items.
            // Which makes the tests very brittle and is generally crap.
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.Strength)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.Life)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.DamageScaling)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.AttackSpeedLocal)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.AttackSpeedGlobal)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.ColdResistance)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.FireResistance)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.LightningResistance)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.ChaosResistance)));
            ModParserCollection.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.AllElementsResistance)));
        }
    }
}