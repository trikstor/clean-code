using System.Collections.Generic;
using System.Linq;
using Markdown.TokenReaders;
using NUnit.Framework;

namespace Markdown
{
    public class Md
    {
        private Dictionary<char, IReader> TokenReaders { get; }
        private List<char> CurrMdSymbols { get; }

        public Md(List<IReader> tokenReaders)
        {
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x);
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
        }

        public Md()
        {
            var tokenReaders = new List<IReader>
            {
                new HeadersReader(),
                new UnderlineReader(),
                new HorizontalDelimiterReader(),
                new QuotesReader()
            };
            TokenReaders = tokenReaders.ToDictionary(x => x.Symbol, x => x);
            CurrMdSymbols = tokenReaders.Select(x => x.Symbol).ToList();
        }

        public string RenderToHtml(string markdown)
        {
            return Render(markdown, new HtmlConvertor());
        }

        public string Render(string markdown, ITokenConverter converter)
        {
            var renderedTokens = MarkdownToTokens(markdown).Select(converter.Convert);
            return string.Join("", renderedTokens);
        }

        public IEnumerable<Token> MarkdownToTokens(string input)
        {
            var currIndex = 0;
            while (currIndex < input.Length)
            {
                var currToken = GetNextToken(input, currIndex);
                if (currToken.BlockOpen)
                {
                    var currBlockTag = currToken.BlockTag;
                    var internalTokens = MarkdownToTokensInternal(currToken.Text).ToList();
                    SetBlockTagAndFrame(internalTokens, currBlockTag);
                    foreach (var token in internalTokens)
                    {
                        yield return token;
                    }
                }
                else
                {
                    yield return currToken;
                }
                if (currIndex != currToken.StartIndex + currToken.Text.Length)
                    currIndex = currToken.StartIndex + currToken.Text.Length;
                else
                    currIndex++;
            }
        }

        private List<Token> SetBlockTagAndFrame(List<Token> internalTokens, TokenType currBlockTag)
        {
            internalTokens[0].BlockOpen = true;
            internalTokens[0].BlockTag = currBlockTag;
            internalTokens[internalTokens.Count - 1].BlockClose = true;
            internalTokens[internalTokens.Count - 1].BlockTag = currBlockTag;
            return internalTokens;
        }
        private IEnumerable<Token> MarkdownToTokensInternal(string input)
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