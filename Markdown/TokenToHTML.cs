using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Markdown.Token;

namespace Markdown
{
    public static class TokenToHTML
    {

        public static Token Convert(Token token)
        {
            if (token.Type == "Default")
                return token;
            var tagName = token.TokenTypes[token.Type];
            if(token.Type == "Horizontal")
                return new Token($"<{tagName}/>", token.StartIndex);
            return new Token($"<{tagName}>{token.Text}</{tagName}>", token.StartIndex);
        }
    }
}
