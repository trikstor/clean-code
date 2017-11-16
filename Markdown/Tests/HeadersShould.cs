using FluentAssertions;
using Markdown.Parsers;
using NUnit.Framework;

namespace Markdown.Tests
{
    [TestFixture]
    public class HeadersShould
    {
        [TestCase("#testWord", "testWord", "h1", TestName = "Заголовок первого уровня")]
        [TestCase("##testWord", "testWord", "h2", TestName = "Заголовок второго уровня")]
        [TestCase("###testWord", "testWord", "h3", TestName = "Заголовок третьего уровня")]
        [TestCase("#testWord\nNextRow", "testWord", "h1", TestName =
            "Заголовок не активен при переносе строки.")]
        public void Parse_CorrectToken(string input, string tokenText, string type)
        {
            var resToken = new Headers().Read(input, 0);

            resToken.Tag.Should().Be(type);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
