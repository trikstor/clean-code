using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Shielding : IParseable
    {
        public Token Parse(string input, int inputIndex)
        {
            return new Token(input[inputIndex + 1] + UntillStopSymbol.Parse(input, inputIndex + 2, MarkdownSymbols.Symbols).Text, 
                inputIndex + 2);
        }
    }
}
