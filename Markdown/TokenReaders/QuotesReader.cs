
namespace Markdown.TokenReaders
{
    public class QuotesReader : CommonReaderEnviron, IReader
    {
        public char Symbol { get; } = MarkdownSymbols.Quote;
        public Token Read(string input, int inputIndex)
        {
            var startIndex = inputIndex;
            if (inputIndex + 1 <= input.Length - 1 && 
                input[inputIndex + 1] == MarkdownSymbols.Quote)
            {
                inputIndex = GetTagIndexWithTrueEnviron(input, inputIndex + 2, CheckQuotesEnviron);
                if (inputIndex != -1)
                {
                    var token = new Token(input.Substring(startIndex + 2, inputIndex - startIndex - 2), startIndex + 2);
                    token.Tag = TokenType.Quotes;
                    return token;
                }
            }
            return AbstractReader.Read(input, startIndex + 1, MarkdownSymbols.AllSymbols);
        }

        private bool CheckQuotesEnviron(string input, int inputIndex)
        {
            return inputIndex != input.Length - 1 && input[inputIndex] == MarkdownSymbols.Quote && input[inputIndex + 1] == MarkdownSymbols.Quote;
        }
    }
}
