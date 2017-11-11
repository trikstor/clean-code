using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class NoMdSymbols : IParse
    {
        public Environ SymbolEnviron { get; }

        public Token Parse(string input)
        {

        }
    }
}
