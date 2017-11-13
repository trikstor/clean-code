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
            var tempInputIndex = inputIndex;
            var startToken = UntillStopSymbol.Parse(input, inputIndex + 1, '_');
            if (startToken.StartIndex + startToken.Text.Length == input.Length || input[inputIndex + 1] == ' ')
                return new Token('_' + startToken.Text, inputIndex);
            startToken.StartIndex += 1;

            var tempInput = inputIndex;
            var found = false;
            inputIndex += 1;
            for (; inputIndex < input.Length; inputIndex++)
            {
                if ((inputIndex + 1 != input.Length && input[inputIndex] == '_' && input[inputIndex + 1] != '_' && input[inputIndex - 1] != '_') || 
                    (inputIndex + 1 == input.Length && input[inputIndex] == '_' && input[inputIndex - 1] != '_'))
                {
                    found = true;
                    break;
                }
            }
            var resToken = new Token(input.Substring(startToken.StartIndex - 1, inputIndex - startToken.StartIndex + 1), tempInput + 2);
            if (found)
            {
                if(resToken.Text[resToken.Text.Length - 1] == ' ')
                    return new Token('_' + startToken.Text, tempInputIndex);
                resToken.Type = Token.TokenType.Italic;
            }
            else
            {
                return new Token("_" + startToken.Text, tempInput);
            }
            return resToken;
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
            var resToken = new Token(input.Substring(startToken.StartIndex, inputIndex - startToken.StartIndex), tempInput + 4);
            if (found)
            {
                var newStr = RenderToHtml(resToken.Text);
                resToken = new Token(newStr, resToken.StartIndex);
                resToken.Type = Token.TokenType.Bold;
            }
            else
            {
                return new Token("__" + startToken.Text, tempInput);
            }
            return resToken;
        }

        public string RenderToHtml(string markdown)
        {
            var html = new TokenToHTML();
            var res = MarkdownToTokens(markdown).Select(token => html.Convert(token)).Select(token => token.Text);
            return string.Join("", res);
        }

        public IEnumerable<Token> MarkdownToTokens(string input)
        {
            var currIndex = 0;
            while (currIndex < input.Length)
            {
                Token currToken;
                if (input[currIndex] != '_')
                    currToken = UntillStopSymbol.Parse(input, currIndex, '_');
                else
                    currToken = ParseSingle(input, currIndex);
                currIndex = currToken.StartIndex + currToken.Text.Length;
                yield return currToken;
            }
        }
    }
}
