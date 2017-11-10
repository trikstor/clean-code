using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class DoubleUnderline : IReplaceable
    {
        public char Symbol { get; }
        public Environ EnvironOfReplace { get; }
        public string[] Substitute { get; }
        private int Registr = -1;

        public DoubleUnderline()
        {

        }

        public string Replace(string input, int indexOfsymbol)
        {

        }
    }
}
