using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class Header : IReplaceable
    {

        public char Symbol { get; }
        public Environ EnvironOfReplace { get; }
        public string[] Substitute { get; }

        public Header()
        {

        }

        public string Replace(string input, int indexOfsymbol)
        {

        }
    }
}
