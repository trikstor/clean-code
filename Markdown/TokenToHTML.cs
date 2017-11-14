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

        public TokenToHTML()
        {
            TokenTypeToTag = new Dictionary<TokenType, string>
            {
                {TokenType.Bold, "strong"},
                {TokenType.Italic, "em"},
                {TokenType.Header, "h1"},
                {TokenType.Code, "code"},
                {TokenType.Horizontal, "hr"},
                {TokenType.Default, "" }
            };
        }

        public Token Convert(Token token)
        {
            if (token.Type == TokenType.Default)
                return token;
            var tagName = TokenTypeToTag[token.Type];
            if(token.Type == TokenType.Horizontal)
                return new Token($"<{tagName}/>", token.StartIndex);
            return new Token($"<{tagName}>{token.Text}</{tagName}>", token.StartIndex);
        }
    }
}
