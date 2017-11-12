using System.Collections.Generic;
using System.Linq;
using Markdown.Parsers;
using NUnit.Framework;

namespace Markdown
{
    public class Md
    {
        private MarkdownSymbols MdSymbols { get; }

        public Md()
        {
            MdSymbols = new MarkdownSymbols(
                new List<IParseable>
            {
                new Headers(),
                new Underline(),
                new Horizontal(),
                new Quotes(),
                new Shielding()
            });
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
                currIndex = currToken.StartIndex + currToken.Text.Length;
                yield return currToken;
            }
        }

        private Token GetNextToken(string input, int inputIndex)
        {
            var currSymbol = input[inputIndex];
            return MdSymbols.SymbolsParsers
                .ContainsKey(currSymbol) ? 
                MdSymbols.SymbolsParsers[currSymbol].Parse(input, inputIndex) : 
                UntillStopSymbol.Parse(input, inputIndex, MarkdownSymbols.Symbols);
        }
    }
}