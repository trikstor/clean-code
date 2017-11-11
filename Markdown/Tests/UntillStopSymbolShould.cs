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
    public class UntillStopSymbolShould
    {
        [TestCase("\\#testWord", "#testWord", TestName = "Игнорирование тега при экранировании.")]
        [TestCase("testWithoutSymbols#testWord", "testWithoutSymbols", TestName = "Прогонка до стоп-символа")]
        public void Parse_CorrectToken(string input, string tokenText, char stopSymbol)
        {
            var resToken = UntillStopSymbol.Parse(input, stopSymbol);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
