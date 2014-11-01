using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemParser : PoeTextValueExtractor, IPoeItemParser
    {
        private readonly IAffixCompendium _affixCompendium;
        private readonly IItemLexicon _itemLexicon;
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private readonly WeaponParser _weaponParser = new WeaponParser();
        private readonly BaseItemParser _baseItemParser = new BaseItemParser();
        private readonly List<ItemMod> _mods = new List<ItemMod>();

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

        public PoeItemParser(IAffixCompendium affixCompendium, IItemLexicon itemLexicon, string gameItemText)
        {
            _affixCompendium = affixCompendium;
            _itemLexicon = itemLexicon;
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
            _affixCompendium.Affixes.Where(IsOnThisItem).ForEach(affix =>
            {
                var roll = GetAffixRoll(affix);
                _mods.Add(new ItemMod(affix, roll.Item1, roll.Item2, ItemLevel));
            });
        }

        private bool IsOnThisItem(IAffix affix)
        {
            var isOnThisItem = _gameText.Contains(affix.MatchText);

            // Some mods look the same in the tooltip but differ in terms of what base type they can appear on.
            // Most commonly local and global versions of the same mod on weapons and non-weapons.
            var isValidOnBaseType = _itemLexicon.IsValidOnBaseType(affix, BaseType);

            return isOnThisItem && isValidOnBaseType;
        }

        private Tuple<string, int> GetAffixRoll(IAffix affix)
        {
            var rollText = _gameText.LineWith(affix.MatchText);
            var match = Regex.Match(rollText, affix.ValueRegEx);

            if (!match.Success)
            {
                throw new ArgumentException(string.Format("Could not match {0} in {1}", affix.MatchText, _gameText.Text));
            }

            return new Tuple<string, int>(rollText, Convert.ToInt32(match.Value));
        }
    }
}