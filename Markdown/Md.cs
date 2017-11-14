using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Markdown.ActiveElements;
using Markdown.Parsers;
using Markdown.Readers;
using NUnit.Framework;

namespace Markdown
{
    public class Md
    {
        private Dictionary<char, IReadable> TokenReaders { get; }
        private List<char> CurrMdSymbols { get; }

        public Md(List<TokenReader> tokenReaders)
        {
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x.Reader);
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
        }

        public Md()
        {
            var tokenReaders = new List<TokenReader>
            {
                new TokenReader(new Headers(), MarkdownSymbols.Header),
                new TokenReader(new Underline(), MarkdownSymbols.Emphasis),
                new TokenReader(new Horizontal(), MarkdownSymbols.Asterisk)
            };
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x.Reader);
        }

        public string RenderToHtml(string markdown)
        {
            var html = new TokenToHTML();
            var res = MarkdownToTokens(markdown).Select(token => html.Convert(token)).Select(token => token.Text);
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
                : AbstractReader.Reader(input, inputIndex, CurrMdSymbols);
        }
    }
}