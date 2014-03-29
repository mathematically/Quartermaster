using System.Windows;
using ExpectedObjects;
using Mathematically.Quartermaster.Tests.Examples;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace Mathematically.Quartermaster.Tests.Specs
{
    [Trait("When Quartermaster starts", "")]
    public class When_quartermaster_starts : QuartermasterInitialised
    {
        [Fact]
        public void If_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void If_the_clipboard_has_non_poe_content_then_no_item_should_be_displayed()
        {
            Clipboard.SetData(DataFormats.Text, Auto.Create<string>());

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void If_the_clipboard_has_a_poe_item_then_that_item_should_be_displayed()
        {
            ClipboardMonitor.CurrentText.Returns(Rings.IronRingText);

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(Rings.IronRing.ToExpectedObject());
            QuartermasterViewModel.Item.ShouldMatch(Rings.IronRing.ToExpectedObject());
        }        
    }
}