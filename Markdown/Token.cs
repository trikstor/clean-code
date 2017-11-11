using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class Token
    {
        public enum TokenType
        {
            Header,
            Bold,
            Italic,
            Code,
            Horizontal
        }

        public string Text { get; }
        public TokenType Type { get; set; }

        public Token(string text)
        {
            
        }
    }
}
