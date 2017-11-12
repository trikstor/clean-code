using FluentAssertions;
using Markdown.Parsers;
using NUnit.Framework;

namespace Markdown.Tests
{
    [TestFixture]
    public class HeadersShould
    {
        [TestCase("#testWord", "testWord", Token.TokenType.Header, TestName = "Заголовок первого уровня")]
        [TestCase("#testWord\nNextRow", "testWord", Token.TokenType.Header, TestName =
            "Заголовок не активен при переносе строки.")]
        public void Parse_CorrectToken(string input, string tokenText, Token.TokenType type)
        {
            var resToken = new Headers().Parse(input, 0);

            resToken.Type.Should().Be(type);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
