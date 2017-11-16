using System.Collections.Generic;
using System.Linq;
using Markdown.Parsers;
using Markdown.Readers;
using Markdown.TokenReaders;

namespace Markdown
{
    public class Md
    {
        private Dictionary<char, IRead> TokenReaders { get; }
        private List<char> CurrMdSymbols { get; }

        public Md(List<IRead> tokenReaders)
        {
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x);
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
        }

        public Md()
        {
            var tokenReaders = new List<IRead>
            {
                new Headers(),
                new Underline(),
                new Horizontal(),
                new Quotes()
            };
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x);
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
        }

        public string RenderToHtml(string markdown)
        {
            var res = MarkdownToTokens(markdown).Select(HtmlConvertor.Convert);
            return string.Join("", res);
        }

        public IEnumerable<Token> MarkdownToTokens(string input)
        {
            var currIndex = 0;
            while (currIndex < input.Length)
            {
                var currToken = GetNextToken(input, currIndex);
                if (currIndex != currToken.StartIndex + currToken.Text.Length)
                    currIndex = currToken.StartIndex + currToken.Text.Length;
                else
                    currIndex++;
                yield return currToken;
            }
        }

        private Token GetNextToken(string input, int inputIndex)
        {
            var currSymbol = input[inputIndex];
            return TokenReaders.ContainsKey(currSymbol)
                ? TokenReaders[currSymbol].Read(input, inputIndex)
                : AbstractReader.Read(input, inputIndex, CurrMdSymbols);
        }
    }
}