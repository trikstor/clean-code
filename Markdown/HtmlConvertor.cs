using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class HtmlConvertor : ITokenConverter
    {
        private readonly Dictionary<TokenType, string> TypeToTag = new Dictionary<TokenType, string>
        {
            { TokenType.Default, ""},
            {TokenType.Bold, "strong" },
            {TokenType.Italic, "em"},
            {TokenType.Header, "h" },
            {TokenType.Quotes, "code" },
            {TokenType.Horizontal, "hr" }
        };

        public string Convert(Token token)
        {
            var result = new StringBuilder();
            var blockTag = ConvertTypeToBlockTag(token);
            var tag = ConvertTypeToTag(token);

            if (token.BlockOpen && !token.BlockClose && token.BlockTag != TokenType.Default)
            {
                result.Append($"<{blockTag}>");
            }

            if (token.BlockOpen && token.BlockClose && token.BlockTag != TokenType.Default)
            {
                result.Append($"<{blockTag}>{token.Text}</{blockTag}>");
            }
            else
            {
                if (token.Tag == TokenType.Default)
                    result.Append(token.Text);
                else
                    result.Append(token.Tag == TokenType.Horizontal ? $"<{tag}/>" : 
                        $"<{tag}>{token.Text}</{tag}>");
            }

            if (token.BlockClose && !token.BlockOpen && token.BlockTag != TokenType.Default)
            {
                result.Append($"</{blockTag}>");
            }
            return result.ToString();
        }

        private string ConvertTypeToTag(Token token)
        {
            if (token.Tag == TokenType.Header)
                return TypeToTag[token.Tag] + token.TagLevel;
            return TypeToTag[token.Tag];
        }

        private string ConvertTypeToBlockTag(Token token)
        {
            return TypeToTag[token.BlockTag];
        }
    }
}
