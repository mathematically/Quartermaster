using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using ExpectedObjects;
using FluentAssertions;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Examples;
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

        [FirstClassTests]
        public static TestCase<AutoDisplayClipboardItemFeature>[] Example_item_tests()
        {
            var testCases = new[]
            {
                new 
                {
                    GameText = Weapons.DriftwoodWandText,
                    ExpectedItem = Weapons.DriftwoodWand,
                    DPS = Weapons.DriftwoodWandDPS,
                },

                new
                {
                    GameText = Weapons.DriftwoodMaulText,
                    ExpectedItem = Weapons.DriftwoodMaul,
                    DPS = Weapons.DriftwoodMaulDPS,
                },

                new
                {
                    GameText = Weapons.HeavyShortBowText,
                    ExpectedItem = Weapons.HeavyShortBow,
                    DPS = Weapons.HeavyShortBowDPS,
                },

                new
                {
                    GameText = Weapons.HypnoticWingText,
                    ExpectedItem = Weapons.HypnoticWing,
                    DPS = Weapons.HypnoticWingDPS,
                },

                new 
                {
                    GameText = Weapons.CorpseBlastText,
                    ExpectedItem = Weapons.CorpseBlast,
                    DPS = Weapons.CorpseBlastDPS,
                },

                new 
                {
                    GameText = Weapons.CorpseBlastText,
                    ExpectedItem = Weapons.CorpseBlast,
                    DPS = Weapons.CorpseBlastDPS,
                },

                new 
                {
                    GameText = Rings.IronRingText,
                    ExpectedItem = Rings.IronRing,
                    DPS = 0.0,
                },

                new 
                {
                    GameText = Rings.KaomsSignText,
                    ExpectedItem = Rings.KaomsSign,
                    DPS = 0.0,
                },

                new 
                {
                    GameText = Rings.SapphireRingText,
                    ExpectedItem = Rings.SapphireRing,
                    DPS = 0.0,
                },

                new 
                {
                    GameText = Rings.ThirstyRubyRingOfSuccessText,
                    ExpectedItem = Rings.ThirstyRubyRingOfSuccess,
                    DPS = 0.0,
                },
            };

            return testCases.Select(c => new TestCase<AutoDisplayClipboardItemFeature>(expect => expect.Copying_game_text_into_clipboard_produces_correct_item(c.GameText, c.ExpectedItem, c.DPS))).ToArray();
        }


        private void Copying_game_text_into_clipboard_produces_correct_item(string gameItemText, PoeItem expectedItem, double dps)
        {
            try
            {
                StartQuartermaster();

                CopyIntoClipboard(gameItemText);

                Quartermaster.Item.ShouldMatch(expectedItem.ToExpectedObject());
                Quartermaster.Item.Damage.DPS.Should().Be(dps);

                _quartermasterViewModel.Item.ShouldMatch(expectedItem.ToExpectedObject());
                _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);

            }
            catch (Exception)
            {
                Debug.WriteLine(gameItemText);
                throw;
            }
        }

        [Theory]
        [InlineData(Rings.IronRingText, false)]
        [InlineData(Weapons.DriftwoodMaulText, true)]
        public void Weapon_property_should_only_be_set_for_weapons(string gameItemText, bool isWeapon)
        {
            StartQuartermaster();

            CopyIntoClipboard(gameItemText);

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
            ClipboardMonitor.CurrentText.Returns(Rings.IronRingText);

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(Rings.IronRing.ToExpectedObject());
            _quartermasterViewModel.Item.ShouldMatch(Rings.IronRing.ToExpectedObject());
        }
    }
}