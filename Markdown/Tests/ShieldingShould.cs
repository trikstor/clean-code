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
        [TestCase("\\#testWord", "#testWord", TestName = "Токен без символов экранирования.")]
        public void Parse_CorrectToken(string input, string tokenText)
        {
            var resToken = new Headers().Parse(input);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
