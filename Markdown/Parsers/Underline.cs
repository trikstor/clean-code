using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Underline : IParseable
    {
        public bool OpenEm = false;
        public Token Parse(string input, int inputIndex)
        {
            if (inputIndex + 1 > input.Length - 1 || char.IsDigit(input[inputIndex + 1]))
            {
                return new Token(input[0] + UntillStopSymbol.Parse(input, inputIndex + 1, MarkdownSymbols.Symbols).Text,
                    inputIndex);
            }
            if (inputIndex + 1 > input.Length - 1  || input[inputIndex + 1] != '_')
                return ParseSingle(input, inputIndex);
            return ParseDouble(input, inputIndex);
        }

        private Token ParseSingle(string input, int inputIndex)
        {
            var token = UntillStopSymbol.Parse(input, inputIndex + 1, '_');
            if (input.EndsWith(token.Text) || input[inputIndex + 1])
                return new Token('_' + token.Text, inputIndex);

            token.Type = Token.TokenType.Italic;
            token.StartIndex += 1;
            return token;
        }

        private Token ParseDouble(string input, int inputIndex)
        {
            var tempInput = inputIndex;
            var startToken = UntillStopSymbol.Parse(input, inputIndex + 2, '_');
            if (startToken.Text == "")
                return startToken;
            var finishToken = startToken;
            var found = false;
            inputIndex += 2;
            for (; inputIndex < input.Length - 1; inputIndex++)
            {
                if (input[inputIndex] == '_' && input[inputIndex + 1] == '_')
                {
                    found = true;
                    break;
                }
            }

            var resToken = new Token(input.Substring(startToken.StartIndex, inputIndex - startToken.StartIndex), startToken.StartIndex);
            if(found)
                resToken.Type = Token.TokenType.Bold;
            else
            {
                return new Token("__" + startToken.Text, tempInput);
            }
            return resToken;
        }
    }
}
