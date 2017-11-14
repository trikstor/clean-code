using Markdown.Parsers;
using Markdown.Readers;

namespace Markdown.TokenReaders
{
    public class Quotes : IReadable
    {
        public Token Read(string input, int inputIndex)
        {
            if (inputIndex + 1 <= input.Length - 1 && 
                input[inputIndex + 1] == MarkdownSymbols.Quote)
            {
                var token = AbstractReader.Read(input, inputIndex + 2, MarkdownSymbols.Quote);
                if (input[token.StartIndex + token.Text.Length] == MarkdownSymbols.Quote)
                {
                    token.Type = Token.TokenType.Code;
                    return token;
                }
            }
            return AbstractReader.Read(input, inputIndex, MarkdownSymbols.AllSymbols);
        }
    }
}
