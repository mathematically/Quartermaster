using System;
using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemParser : PoeTextValueExtractor, IPoeItemParser
    {
        private readonly IAffixCompendium _affixCompendium;
        private readonly IItemLexicon _itemLexicon;
        private readonly IModParserCollection _modParserCollection;
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private readonly WeaponParser _weaponParser = new WeaponParser();
        private readonly BaseItemParser _baseItemParser = new BaseItemParser();
        private readonly List<IItemMod> _mods = new List<IItemMod>();

        private readonly GameText _gameText;

        public string Name { get; private set; }

        public ItemRarity Rarity { get; private set; }

        public int ItemLevel { get; private set; }

        public BaseItemType BaseType { get; private set; }

        public ItemCategory Category { get; private set; }

        public bool IsWeapon
        {
            get { return _weaponParser.IsWeapon; }
        }

        public IWeaponDamage Damage
        {
            get { return _weaponParser; }
        }

        public IEnumerable<IItemMod> Mods
        {
            get { return _mods; }
        }



        public PoeItemParser(IAffixCompendium affixCompendium, IItemLexicon itemLexicon, IModParserCollection modParserCollection, string gameItemText)
        {
            _affixCompendium = affixCompendium;
            _itemLexicon = itemLexicon;
            _modParserCollection = modParserCollection;

            _gameText = new GameText(gameItemText);
        }

        public void Parse()
        {
            Name = _gameText[NameLineIndex];
            Rarity = ParseRarity();
            ItemLevel = ParseItemLevel();
            BaseType = _baseItemParser.Parse(_gameText);
            Category = _itemLexicon.GetItemCategory(BaseType);

            ParseWeapon();
            ParseMods();
        }

        private ItemRarity ParseRarity()
        {
            var rarityText = ValueTextFrom(_gameText[RarityLineIndex]);

            return (ItemRarity) Enum.Parse(typeof (ItemRarity), rarityText);
        }

        private int ParseItemLevel()
        {
            return IntegerFrom(_gameText.LineWith(PoeText.ITEMLEVEL_LABEL));
        }

        private void ParseWeapon()
        {
            _weaponParser.Parse(_gameText);
        }

        private void ParseMods()
        {
            IEnumerable<string> workingModText = _gameText.ModText.ToList();

            _modParserCollection.Parsers.ForEach(p =>
            {
                var result = p.TryParse(ItemLevel, BaseType, workingModText);
                if (!result.HasDiscoveredMods) return;

                workingModText = result.RemainingModTextLines;
                result.DiscoveredMods.ForEach(m => _mods.Add(m));
            });
        }

    }
}