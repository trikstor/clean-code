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
        // Тут блоковые символы Маркдауна
        public Dictionary<char, IParse> SymbolsParsers { get; }

        private readonly char[] Symbols =
        {
            '_',
            '#',
            '*'
        };

        public MarkdownSymbols(IReadOnlyCollection<IParse> parsers)
        {
            if(Symbols.Length > parsers.Count)
                throw new ArgumentException("Символов больше чем парсеров.");

            SymbolsParsers = new Dictionary<char, IParse>();

            int symbolIndex = 0;
            foreach (var parser in parsers)
            {
                SymbolsParsers.Add(Symbols[symbolIndex], parser);
                symbolIndex++;
            }
        }
    }
}
