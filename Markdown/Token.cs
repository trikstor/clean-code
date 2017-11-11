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
            Horizontal,
            Default
        }

        public string Text { get; }
        public TokenType Type { get; set; }
        public int StratIndex { get; set; }

        public Token(string text, int stratIndex)
        {
            Text = text;
            Type = TokenType.Default;
            StratIndex = stratIndex;
        }
    }
}
