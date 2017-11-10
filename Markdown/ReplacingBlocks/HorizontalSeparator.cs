using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.ReplacingBlocks
{
    public class HorizontalSeparator : IReplaceable
    {
        public char Symbol { get; }
        public Environ EnvironOfReplace { get; }
        public string[] Substitute { get; }
        private int Registr = -1;

        public HorizontalSeparator()
        {

        }

        public string Replace(string input, int indexOfsymbol)
        {

        }
    }
}
