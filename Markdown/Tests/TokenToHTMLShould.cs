using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using static Markdown.Token;

namespace Markdown.Tests
{
    [TestFixture]
    public class TokenToHTMLShould
    {
        private TokenToHTML Converter { get; set; }

        [SetUp]
        public void SetUp()
        {
            Converter = new TokenToHTML();
        }

        [Test]
        public void ProduceEmptyString_EmptyTextInToken()
        {
            var testToken = new Token("");
            Converter.Convert(testToken).Should().Be("");
        }

        [Test]
        public void CorrectConvertation_CorrectToken(Token token)
        {
            var testToken = new Token("testWord") {Type = TokenType.Bold};
            Converter.Convert(testToken).Should().Be("<strong>testWord</strong>");
        }
    }
}
