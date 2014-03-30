using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemParser : IPoeItemParser
    {
        private readonly CommonPropertyParser _commonProperties;
        private readonly WeaponParser _weapon;
        private readonly ModsParser _mods;

        public string Name
        {
            get { return _commonProperties.Name; }
        }

        public ItemRarity Rarity
        {
            get { return _commonProperties.Rarity; }
        }

        public int ItemLevel
        {
            get { return _commonProperties.ItemLevel; }
        }

        public bool IsWeapon
        {
            get { return _weapon.IsWeapon; }
        }

        public IWeaponDamage Damage
        {
            get { return _weapon; }
        }

        public IEnumerable<Affix> Affixes
        {
            get { return _mods.Affixes; }
        }

        public PoeItemParser(string gameItemText)
        {
            var gameText = new GameText(gameItemText);

            _commonProperties = new CommonPropertyParser(gameText);
            _weapon = new WeaponParser(gameText);
            _mods = new ModsParser(gameText);
        }

        public void Parse()
        {
            _commonProperties.Parse();
            _weapon.Parse();
            _mods.Parse(_commonProperties.ItemLevel);
        }
    }
}