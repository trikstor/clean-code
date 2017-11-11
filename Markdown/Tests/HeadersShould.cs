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
    public class HeadersShould
    {
        [TestCase("#testWord", "testWord", "<h1>", TestName = "Заголовок первого уровня")]
        [TestCase("##testWord", "testWord", "<h2>", TestName = "Заголовок второго уровня")]
        [TestCase("###testWord", "testWord", "<h3>", TestName = "Заголовок третьего уровня")]
        [TestCase("####testWord", "testWord", "<h4>", TestName = "Заголовок червертого уровня")]
        [TestCase("#testWord /n NextRow", "testWord", "<h1>", TestName =
            "Заголовок не активен при переносе строки.")]
        public void Parse_CorrectToken(string input, string tokenText, string openTag)
        {
            var resToken = new Headers().Parse(input);

            resToken.Tag[0].Should().Be(openTag);
            resToken.Text.Should().Be(tokenText);
        }
    }
}
