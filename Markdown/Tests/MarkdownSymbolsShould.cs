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
        private List<IParse> Parsers { get; set; }
        [SetUp]
        public void SetUp()
        {
            Parsers = new List<IParse>
            {
                new Headers(),
                new NoMdSymbols()
            };
        }

        [Test]
        public void CorrectBuilding_CorrectParsersQuantity()
        {
            new MarkdownSymbols(Parsers).SymbolsParsers.Count.Should().Be(2);
        }

        [Test]
        public void ThrowException_ParsersMoreThenSymbols()
        {
            Parsers.Add(new NoMdSymbols());
            Action res = () => { new MarkdownSymbols(Parsers); };
            res.ShouldThrow<ArgumentException>().WithMessage("Символов больше чем парсеров.");
        }
    }
}
