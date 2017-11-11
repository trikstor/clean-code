using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Markdown.Parsers;
using NUnit.Framework;

namespace Markdown.Tests
{
    [TestFixture]
    public class ShieldingShould
    {
        private IParseable Shielder { get; set; }

        [SetUp]
        public void SetUp()
        {
            Shielder = new Shielding();
        }

        [TestCase("#testWord", "#testWord", TestName = "Токен без символов экранирования.")]
        public void Parse_CorrectToken(string input, string tokenText)
        {
            var resToken = Shielder.Parse(input, 0);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
