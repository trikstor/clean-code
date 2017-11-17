using NUnit.Framework;
using FluentAssertions;

namespace Markdown.Tests
{
    [TestFixture]
    public class HtmlConvertorShould
    {
        private ITokenConverter Convertor;
        [SetUp]
        public void SetUp()
        {
            Convertor = new Markdown.HtmlConvertor();
        }

        [Test]
        public void ProduceEmptyString_EmptyTextInTokenWithoutType()
        {
            var testToken = new Token("", 0);
            Convertor.Convert(testToken).Should().Be("");
        }

        [Test]
        public void CorrectConvertationDoubleTag_CorrectToken()
        {
            var testToken = new Token("testWord", 0);
            testToken.Tag = TokenType.Bold;
            Convertor.Convert(testToken).Should().Be("<strong>testWord</strong>");
        }

        [Test]
        public void CorrectConvertationSingleTag_CorrectToken()
        {
            var testToken = new Token("", 0);
            testToken.Tag = TokenType.Horizontal;
            Convertor.Convert(testToken).Should().Be("<hr/>");
        }
    }
}
