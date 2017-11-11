using System.Collections.Generic;
using Markdown.Parsers;

namespace Markdown
{    public class MarkdownParser
    {
        public static int CurrInputIndex = 0;
        public static List<IParse> Parsers;

        public MarkdownParser()
        {
            Parsers = new List<IParse>
            {
                new Headers(),
                new UntillStopSymbol()
            };
        }

        public IEnumerable<Token> MarkdownToTokens(string input)
        {
            // Передача функции парсинга в специализированные методы
        }

    }
}