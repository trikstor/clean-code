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
        public Dictionary<string, string> TokenTypes
            = new Dictionary<string, string>
            {
                    {"Header", "h1"},
                    {"Bold" , "strong"},
                    {"Italic" , "em"},
                    {"Code", "code"},
                    {"Horizontal", "hr"},
                    {"Default", ""}
            };

        public string Text { get; }
        public string Type { get; set; }
        public int StartIndex { get; set; }

        public Token(string text, int stratIndex)
        {
            Text = text;
            Type = TokenTypes["Default"];
            StartIndex = stratIndex;
        }
    }
}
