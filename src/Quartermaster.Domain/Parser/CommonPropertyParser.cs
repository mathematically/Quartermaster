using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class CommonPropertyParser : PoeTextValueExtractor, ICommonPoeItemData
    {
        // These line positions are always the same
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private readonly GameText _gameText;

        public string Name { get; private set; }
        public ItemRarity Rarity { get; private set; }
        public int ItemLevel { get; private set; }

        public CommonPropertyParser(GameText gameText)
        {
            _gameText = gameText;
        }

        public void Parse()
        {
            Name = _gameText[NameLineIndex];
            Rarity = ParseRarity();
            ItemLevel = ParseItemLevel();
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
    }
}