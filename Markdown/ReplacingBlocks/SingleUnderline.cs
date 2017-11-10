using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class SingleUnderline : IReplaceable
    {
        public char Symbol { get; }
        public Environ EnvironOfReplace { get; }
        public string[] Substitute { get; }

        private int Registr = -1;

        public SingleUnderline()
        {

        }

        public string Replace(string input, int indexOfsymbol)
        {

        }
    }
}
