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
        public void ProduceEmptyString_EmptyTextInTokenWithoutType()
        {
            var testToken = new Token("");
            Converter.Convert(testToken).Text.Should().Be("");
        }

        [Test]
        public void CorrectConvertationDoubleTag_CorrectToken()
        {
            var testToken = new Token("testWord") {Type = TokenType.Bold};
            Converter.Convert(testToken).Text.Should().Be("<strong>testWord</strong>");
        }

        [Test]
        public void CorrectConvertationSingleTag_CorrectToken()
        {
            var testToken = new Token("") { Type = TokenType.Horizontal };
            Converter.Convert(testToken).Text.Should().Be("<hr/>");
        }
    }
}
