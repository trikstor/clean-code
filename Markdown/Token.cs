using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Parsers;

namespace Markdown
{
    public class Token
    {
        public Dictionary<string, string> TokenTypes { get; set; }
        public string Text { get; }
        public string Tag { get; set; }
        public int StartIndex { get; set; }

        public Token(string text, int stratIndex)
        {
            TokenTypes = new Dictionary<string, string>
            {
                {"Header", "h"},
                {"Bold" , "strong"},
                {"Italic" , "em"},
                {"Code", "code"},
                {"Horizontal", "hr"},
                {"Default", ""}
            };

            Text = text;
            Tag = TokenTypes["Default"];
            StartIndex = stratIndex;
        }

        public void AddToTag(string str)
        {
            
        }
    }
}
