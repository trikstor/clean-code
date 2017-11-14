using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Readers;

namespace Markdown.ActiveElements
{
    public class TokenReader
    {
        public char Symbol { get; }
        public IReadable Reader { get; }
        public TokenReader(IReadable reader, char symbol)
        {
            Symbol = symbol;
            Reader = reader;
        }
    }
}
