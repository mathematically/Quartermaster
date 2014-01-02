using System.Collections.Generic;
using ExpectedObjects;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Ploeh.AutoFixture;

namespace Mathematically.Quartermaster.Tests.Fixtures
{
    public class QuartermasterFixture
    {
        protected readonly Fixture Auto = new Fixture();

        protected readonly ExpectedObject NoItem = new EmptyPoeItem().ToExpectedObject();
        protected readonly ExpectedObject NotAWeapon = new EmptyPoeWeapon().ToExpectedObject();

        private readonly Dictionary<string, PoeItem> _items = new Dictionary<string, PoeItem>();
        private readonly Dictionary<string, ExpectedObject> _expectedItems = new Dictionary<string, ExpectedObject>();

        #region RINGS

        #region Iron Ring

        protected const string IronRingName = "Iron Ring";

        protected static readonly PoeItem IronRing = new PoeItem(
            IronRingName,
            ItemRarity.Normal,
            4
            );

        protected readonly ExpectedObject IronRingItem = IronRing.ToExpectedObject();

        #endregion

        #region Sapphire Ring

        protected const string SapphireRingName = "Sapphire Ring";

        protected static readonly PoeItem SapphireRing = new PoeItem(
            SapphireRingName,
            ItemRarity.Normal,
            15
            );

        protected readonly ExpectedObject SapphireRingItem = SapphireRing.ToExpectedObject();

        #endregion

        #region Thirsty Ruby Ring Of Success

        protected const string ThirstyRubyRingOfSuccessName = "Thirsty Ruby Ring of Success";

        protected static readonly PoeItem ThirstyRubyRingOfSuccess = new PoeItem(
            ThirstyRubyRingOfSuccessName,
            ItemRarity.Magic,
            16
            );

        protected readonly ExpectedObject ThirstyRubyRingOfSuccessItem = ThirstyRubyRingOfSuccess.ToExpectedObject();

        #endregion

        #endregion 

        #region WEAPONS

        #region Driftwood Wand

        protected const string DriftwoodWandName = "Driftwood Wand";

        protected static readonly PoeItem DriftwoodWand = new PoeItem(
            DriftwoodWandName,
            ItemRarity.Normal,
            4
            );

        protected readonly ExpectedObject DriftwoodWandItem = DriftwoodWand.ToExpectedObject();

        #endregion

        #region Driftwood Maul

        protected const string DriftwoodMaulName = "Driftwood Maul";

        protected static readonly PoeItem DriftwoodMaul = new PoeItem(
            DriftwoodMaulName,
            ItemRarity.Normal,
            4
            );

        protected readonly ExpectedObject DriftwoodMaulItem = DriftwoodMaul.ToExpectedObject();

        #endregion

        #endregion

        protected QuartermasterFixture( )
        {
            // Indexed access to the test items makes theories easier to write.
            _items = new Dictionary<string, PoeItem>()
            {
                {IronRing.Name, IronRing},
                {SapphireRing.Name, SapphireRing},
                {ThirstyRubyRingOfSuccess.Name, ThirstyRubyRingOfSuccess},
                {DriftwoodWand.Name, DriftwoodWand},
                {DriftwoodMaul.Name, DriftwoodMaul},
            };

            // And if we have an expected object for each we can do easy comparison checks.
            _items.ForEach(i => _expectedItems.Add(i.Key, i.Value.ToExpectedObject()));
        }

        protected ExpectedObject GetExpectedItem(string itemName)
        {
            return _expectedItems[itemName];
        }

        protected PoeItem GetItem(string itemName)
        {
            return _items[itemName];
        }
    }
}