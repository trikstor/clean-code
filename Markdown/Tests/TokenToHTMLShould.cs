using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Markdown.Tests
{
    [TestFixture]
    public class TokenToHTMLShould
    {
        [Test]
        public void ProduceEmptyString_EmptyTextInToken()
        {
            var testToken = new Token("");
            TokenToHTML.Convert(testToken).Should().Be("");
        }

        [Test]
        public void CorrectConvertation_CorrectToken(Token token)
        {
            var testToken = new Token("testWord") {Tag = HTMLTags.Bold};
            TokenToHTML.Convert(testToken).Should().Be("<strong>testWord</strong>");
        }
    }
}
