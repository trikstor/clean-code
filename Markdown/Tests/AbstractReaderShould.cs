using FluentAssertions;
using Markdown.TokenReaders;
using NUnit.Framework;

namespace Markdown.Tests
{
    [TestFixture]
    public class AbstractReaderShould
    {
 
        [TestCase("testWithoutSymbols#testWord", "testWithoutSymbols", '#', TestName = "Прогонка до стоп-символа")]
        public void Parse_CorrectToken(string input, string tokenText, char stopSymbol)
        {
            var resToken = AbstractReader.Read(input, 0,  stopSymbol);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
