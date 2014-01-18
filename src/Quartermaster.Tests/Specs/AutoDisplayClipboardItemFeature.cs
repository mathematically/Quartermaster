using System.Windows;
using Caliburn.Micro;
using ExpectedObjects;
using FluentAssertions;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Mathematically.Quartermaster.ViewModels;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class AutoDisplayClipboardItemFeature : QuartermasterFixture
    {
        private QuartermasterViewModel _quartermasterViewModel;

        protected override void StartQuartermaster()
        {
            base.StartQuartermaster();

            _quartermasterViewModel = new QuartermasterViewModel(Substitute.For<IWindowManager>(), Quartermaster, ClipboardMonitor);
            _quartermasterViewModel.MonitorEvents();
        }

        [Theory]
        [InlineData(Rings.IronRing, IronRingName, 0.0)]
        [InlineData(Rings.SapphireRing, SapphireRingName, 0.0)]
        [InlineData(Rings.ThirstyRubyRingOfSuccess, ThirstyRubyRingOfSuccessName, 0.0)]
        [InlineData(Weapons.DriftwoodWand, DriftwoodWandName, Weapons.DriftwoodWandDPS)]
        [InlineData(Weapons.DriftwoodMaul, DriftwoodMaulName, Weapons.DriftwoodMaulDPS)]
        [InlineData(Weapons.HeavyShortBow, HeavyShortBowName, Weapons.HeavyShortBowDPS)]
        [InlineData(Weapons.HypnoticWing, HypnoticWingName, Weapons.HypnoticWingDPS)]
        public void Copying_item_text_in_game_sets_the_displayed_item_to_the_item_that_text_represents(
            string gameItemText, string itemName, double dps)
        {
            var expectedItem = GetExpectedItem(itemName);
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            Quartermaster.Item.ShouldMatch(expectedItem);
            Quartermaster.Item.Damage.DPS.Should().Be(dps);

            _quartermasterViewModel.Item.ShouldMatch(expectedItem);
            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        [Theory]
        [InlineData(Rings.IronRing, false)]
        [InlineData(Weapons.DriftwoodMaul, true)]
        public void Weapon_property_should_only_be_set_for_weapons(string gameItemText, bool isWeapon)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            if (isWeapon)
                _quartermasterViewModel.Item.Damage.DPS.Should().NotBe(0.0);
            else
                _quartermasterViewModel.Item.Damage.DPS.Should().Be(0.0);

            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }


        [Fact]
        public void On_startup_if_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_non_poe_content_then_no_item_should_be_displayed()
        {
            Clipboard.SetData(DataFormats.Text, Auto.Create<string>());

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_an_iron_ring_then_an_iron_ring_should_be_displayed()
        {
            ClipboardMonitor.CurrentText.Returns(Rings.IronRing);

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(IronRingItem);
            _quartermasterViewModel.Item.ShouldMatch(IronRingItem);
        }
    }
}