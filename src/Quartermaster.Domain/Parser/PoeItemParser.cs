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
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private readonly WeaponParser _weapon = new WeaponParser();
        private readonly List<ItemMod> _mods = new List<ItemMod>();

        private readonly GameText _gameText;

        public string Name
        {
            get; private set;
        }

        public ItemRarity Rarity
        {
            get; private set;
        }

        public int ItemLevel
        {
            get; private set;
        }

        public bool IsWeapon
        {
            get { return _weapon.IsWeapon; }
        }

        public IWeaponDamage Damage
        {
            get { return _weapon; }
        }

        public IEnumerable<IItemMod> Mods
        {
            get { return _mods; }
        }

        public PoeItemParser(IAffixCompendium affixCompendium, string gameItemText)
        {
            _affixCompendium = affixCompendium;
            _gameText = new GameText(gameItemText);
        }

        public void Parse()
        {
            Name = _gameText[NameLineIndex];
            Rarity = ParseRarity();
            ItemLevel = ParseItemLevel();

            _weapon.Parse(_gameText);

            ParseMods();
        }

        private ItemRarity ParseRarity()
        {
            var rarityText = ValueTextFrom(_gameText[RarityLineIndex]);

            return (ItemRarity)Enum.Parse(typeof(ItemRarity), rarityText);
        }

        private int ParseItemLevel()
        {
            return IntegerFrom(_gameText.LineWith(PoeText.ITEMLEVEL_LABEL));
        }

        private void ParseMods()
        {
            _affixCompendium.Affixes.Where(OnThisItem).ForEach(affix =>
            {
                var roll = GetAffixRoll(affix);
                _mods.Add(new ItemMod(affix, roll.Item1, roll.Item2, ItemLevel));
            });
        }

        private bool OnThisItem(IAffix a)
        {
            var textMatch = _gameText.Contains(a.MatchText);
            return textMatch;
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