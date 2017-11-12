using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Underline : IParseable
    {
        public Token Parse(string input, int inputIndex)
        {
            if (char.IsDigit(input[inputIndex + 1]))
            {
                return new Token(input[0] + UntillStopSymbol.Parse(input, inputIndex + 1, MarkdownSymbols.Symbols).Text,
                    inputIndex);
            }
            if (input[inputIndex + 1] != '_')
                return ParseSingle(input, inputIndex);
            return ParseDouble(input, inputIndex);
        }

        private Token ParseSingle(string input, int inputIndex)
        {
            var token = UntillStopSymbol.Parse(input, inputIndex + 1, '_');
            token.Type = Token.TokenType.Italic;
            token.StartIndex += 1;
            return token;
        }

        private Token ParseDouble(string input, int inputIndex)
        {
            var token = UntillStopSymbol.Parse(input, inputIndex + 2, '_');
            token.Type = Token.TokenType.Bold;
            token.StartIndex += 2;
            return token;
        }
    }
}
