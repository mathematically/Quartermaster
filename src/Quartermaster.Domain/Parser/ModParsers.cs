using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class ModParsers: IModParserCollection
    {
        private static readonly List<IModParser> _modParsers = new List<IModParser>();

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
                return _modParsers;
            }
        }

        private void BuildCollectionIfRequired()
        {
            if (_modParsers.Any())
                return;

            // We want a parser of the appropriate type for every affix type.
            _modParsers.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.Life)));
            _modParsers.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.DamageScaling)));
            _modParsers.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.AttackSpeedLocal)));
            _modParsers.Add(new SimpleModParser(_itemLexicon, _affixCompendium.GetAffix(AffixType.AttackSpeedGlobal)));
        }
    }
}