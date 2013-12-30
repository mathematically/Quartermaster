﻿using System.Windows;
using FluentAssertions;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Quartermaster.Infrastructure;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ClipboardMonitorTests
    {
        private ClipboardMonitor _sut;

        [Fact]
        public void If_the_clipboard_already_has_text_new_monitors_will_have_that_text_in_their_item_property()
        {
            Clipboard.SetData(DataFormats.Text, Rings.IronRing);

            _sut = new ClipboardMonitor();

            _sut.CurrentText.Should().Be(Rings.IronRing);
        }
    }
}