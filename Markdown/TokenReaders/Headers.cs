using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Markdown.Readers;

namespace Markdown.Parsers
{
    public class Headers : IRead
    {
        public char Symbol { get; } = MarkdownSymbols.Header;
        public Token Read(string input, int inputIndex)
        {
            var headerLevel = GetHeaderLevel(input, inputIndex);
            var headerToken = AbstractReader.Read(input, inputIndex + headerLevel, '\n');
            headerToken.TokenTypes["Header"] += headerLevel.ToString();
            headerToken.Tag = headerToken.TokenTypes["Header"];
            return headerToken;
        }

        private int GetHeaderLevel(string input, int inputIndex)
        {
            var headerLevel = 0;
            while (inputIndex != input.Length &&
                   input[inputIndex] == MarkdownSymbols.Header)
            {
                headerLevel++;
                inputIndex++;
            }
            return headerLevel;
        }
    }
}