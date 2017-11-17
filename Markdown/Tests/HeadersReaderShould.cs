using FluentAssertions;
using Markdown.TokenReaders;
using NUnit.Framework;

namespace Markdown.Tests
{
    [TestFixture]
    public class HeadersReaderShould
    {
        [TestCase("#testWord", "testWord", TokenType.Header, 1, TestName = "Заголовок первого уровня")]
        [TestCase("##testWord", "testWord", TokenType.Header, 2, TestName = "Заголовок второго уровня")]
        [TestCase("###testWord", "testWord", TokenType.Header, 3, TestName = "Заголовок третьего уровня")]
        [TestCase("#testWord\nNextRow", "testWord", TokenType.Header, 1, TestName =
            "Заголовок не активен при переносе строки.")]
        public void Parse_CorrectToken(string input, string tokenText, TokenType type, int tagLevel)
        {
            var resToken = new HeadersReader().Read(input, 0);

            resToken.Tag.Should().Be(type);
            resToken.Text.Should().Be(tokenText);
            resToken.TagLevel.Should().Be(tagLevel);
        }
    }
}
