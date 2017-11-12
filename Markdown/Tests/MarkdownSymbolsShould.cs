using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Markdown.Parsers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Markdown.Tests
{
    [TestFixture]
    public class MarkdownSymbolsShould
    {
        private List<IParseable> Parsers { get; set; }
        [SetUp]
        public void SetUp()
        {
            Parsers = new List<IParseable>
            {
                new Headers(),
                new Underline(),
                new Quotes(),
                new Horizontal()
            };
        }


        [Test]
        public void ThrowException_ParsersMoreThenSymbols()
        {
            Action res = () => { new MarkdownSymbols(Parsers); };
            res.ShouldThrow<ArgumentException>().WithMessage("Символов больше чем парсеров.");
        }

        [Test]
        public void CorrectBuilding_CorrectParsersQuantity()
        {
            Parsers.Add(new Shielding());
            new MarkdownSymbols(Parsers).SymbolsParsers.Count.Should().Be(5);
        }
    }
}
