using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Readers;

namespace Markdown.Parsers
{
    public class Horizontal : IReadable
    {
        public Token Read(string input, int inputIndex)
        {
            var tt = input[inputIndex + 1];
            if (inputIndex + 2 <= input.Length - 1 && input[inputIndex + 1] == MarkdownSymbols.Asterisk &&
                input[inputIndex + 2] == MarkdownSymbols.Asterisk)
            {
                var token = AbstractReader.Read(input, inputIndex + 3, '\n');
                token.Type = Token.TokenType.Horizontal;
                return token;
            }

            return AbstractReader.Read(input, inputIndex, MarkdownSymbols.AllSymbols);
        }
    }
}
