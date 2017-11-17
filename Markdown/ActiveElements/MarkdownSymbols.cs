using System.Collections.Generic;

namespace Markdown
{
    public static class MarkdownSymbols
    {
        public const char Emphasis = '_';
        public const char Shielding = '\\';
        public const char Space = ' ';
        public const char Quote = '`';
        public const char NewLine = '\n';
        public const char Header = '#';
        public const char Asterisk = '*';

        public static readonly List<char> AllSymbols = new List<char>
        {
            Emphasis,
            Shielding,
            Header,
            Quote,
            Asterisk
        };
    }
}
