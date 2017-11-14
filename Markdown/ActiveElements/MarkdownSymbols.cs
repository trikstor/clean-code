using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Parsers;

namespace Markdown
{
    public static class MarkdownSymbols
    {
        public const char Emphasis = '_';
        public const char Shielding = '\\';
        public const char Space = ' ';
        public const char NewLine = '\n';
        public const char Header = '#';
        public const char Asterisk = '*';

        public static readonly List<char> AllSymbols = new List<char>
        {
            Emphasis,
            Shielding,
            Header,
        };
    }
}
