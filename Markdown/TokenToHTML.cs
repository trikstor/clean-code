using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Markdown.Token;

namespace Markdown
{
    public class TokenToHTML
    {
        private Dictionary<TokenType, string> TokenTypeToTag { get; }
        private List<TokenType> SingleTags { get; }

        public TokenToHTML()
        {
            TokenTypeToTag = new Dictionary<TokenType, string>
            {
                {TokenType.Bold, "<strong>"},
                {TokenType.Italic, "<em>"},
                {TokenType.Header, "<h1>"},
                {TokenType.Code, "<code>"},
                {TokenType.Horizontal, "<hr/>"},
                {TokenType.Default, "" }
            };

            SingleTags = new List<TokenType>
            {
                TokenType.Horizontal
            };
        }

        public Token Convert(Token token)
        {
            if (string.IsNullOrEmpty(token.Text) && token.Type == TokenType.Default)
                return token;
            var openTag = TokenTypeToTag[token.Type];
            var closeTag = "";
            if(!SingleTags.Contains(token.Type))
                closeTag = "</" + TokenTypeToTag[token.Type].Substring(1);
            return new Token(openTag + token.Text + closeTag);
        }
    }
}
