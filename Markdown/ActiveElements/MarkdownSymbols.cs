using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Parsers;

namespace Markdown
{
    public class MarkdownSymbols
    {
        public Dictionary<char, IParseable> SymbolsParsers { get; }

        public static readonly List<char> Symbols = new List<char>
        {
            '#',
            '_',
            '*',
            '`',
            '\\'
        };

        public MarkdownSymbols(IReadOnlyCollection<IParseable> parsers)
        {
            if(Symbols.Count > parsers.Count)
                throw new ArgumentException("Символов больше чем парсеров.");

            SymbolsParsers = new Dictionary<char, IParseable>();

            int symbolIndex = 0;
            foreach (var parser in parsers)
            {
                SymbolsParsers.Add(Symbols[symbolIndex], parser);
                symbolIndex++;
            }
        }
    }
}
