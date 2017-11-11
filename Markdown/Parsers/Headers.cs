using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Headers : IParse
    {
        public Environ SymbolEnviron { get; }
        private string[] HeaderLevels { get; }

        public Headers()
        {
            HeaderLevels = new[]
            {
                "#",
                "##",
                "###",
                "####",
                "#####"
            };
        }

        public Token Parse(string input)
        {

        }
    }
}