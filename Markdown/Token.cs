using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class Token
    {
        public string Text { get; }
        public string[] Tag { get; set; }

        public Token(string text)
        {
            
        }
    }
}
