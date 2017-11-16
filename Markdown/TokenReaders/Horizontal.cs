using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Readers;

namespace Markdown.Parsers
{
    public class Horizontal : IRead
    {
        public char Symbol { get; } = MarkdownSymbols.Asterisk;
        public Token Read(string input, int inputIndex)
        {
            var tt = input[inputIndex + 1];
            if (CheckFullSymbol(input, inputIndex))
            {
                var token = AbstractReader.Read(input, inputIndex + 3, '\n');
                token.Tag = token.TokenTypes["Horizontal"];
                return token;
            }

            return AbstractReader.Read(input, inputIndex, MarkdownSymbols.AllSymbols);
        }

        private bool CheckFullSymbol(string input, int inputIndex)
        {
            return inputIndex + 2 <= input.Length - 1 && input[inputIndex + 1] == MarkdownSymbols.Asterisk &&
                   input[inputIndex + 2] == MarkdownSymbols.Asterisk;
        }
    }
}
