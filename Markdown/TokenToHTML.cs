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
        private Dictionary<TokenType, string> TokenTypeToTag;

        public TokenToHTML()
        {
            TokenTypeToTag = new Dictionary<TokenType, string>
            {
                {TokenType.Bold, "<strong>"},
                {TokenType.Italic, "<em>"},
                {TokenType.Header, "<h1>"},
                {TokenType.Code, "<code>"},
                {TokenType.Horizontal, "<hr/>"}
            };
        }

        public string Convert(Token token)
        {
            // Оборачивание токена в тег
        }
    }
}
