using Markdown.Parsers;
using Markdown.Readers;

namespace Markdown.TokenReaders
{
    public class Quotes : IReadable
    {
        public Token Read(string input, int inputIndex)
        {
            var found = false;
            if (inputIndex + 1 <= input.Length - 1 && 
                input[inputIndex + 1] == MarkdownSymbols.Quote)
            {
                inputIndex += 2;
                var startIndex = inputIndex;
                for (; inputIndex < input.Length - 1; inputIndex++)
                {
                    if (input[inputIndex] == MarkdownSymbols.Quote && input[inputIndex + 1] == MarkdownSymbols.Quote)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    var token = new Token(input.Substring(startIndex, inputIndex - startIndex), startIndex);
                    token.Type = token.TokenTypes["Code"];
                    return token;
                }
            }
            inputIndex++;
            return AbstractReader.Read(input, inputIndex, MarkdownSymbols.AllSymbols);
        }
    }
}
