using System.Collections.Generic;
using Markdown.Parsers;

namespace Markdown
{    public class MarkdownParser
    {
        public static int CurrInputIndex = 0;
        public static List<IParseable> Parsers;

        public MarkdownParser()
        {
            Parsers = new List<IParseable>
            {
                new Headers(),
            };
        }

        public IEnumerable<Token> MarkdownToTokens(string input)
        {
            // Передача функции парсинга в специализированные методы
            return null; //TODO
        }

    }
}