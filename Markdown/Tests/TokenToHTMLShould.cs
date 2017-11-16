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
        [Test]
        public void ProduceEmptyString_EmptyTextInTokenWithoutType()
        {
            var testToken = new Token("", 0);
            TokenToHTML.Convert(testToken).Text.Should().Be("");
        }

        [Test]
        public void CorrectConvertationDoubleTag_CorrectToken()
        {
            var testToken = new Token("testWord", 0);
            testToken.Type = testToken.TokenTypes["Bold"];
            TokenToHTML.Convert(testToken).Text.Should().Be("<strong>testWord</strong>");
        }

        [Test]
        public void CorrectConvertationSingleTag_CorrectToken()
        {
            var testToken = new Token("", 0);
            testToken.Type = testToken.TokenTypes["Horizontal"];
            TokenToHTML.Convert(testToken).Text.Should().Be("<hr/>");
        }
    }
}
