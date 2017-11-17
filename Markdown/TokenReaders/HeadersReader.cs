
namespace Markdown.TokenReaders
{
    public class HeadersReader : IReader
    {
        public char Symbol { get; } = MarkdownSymbols.Header;
        public Token Read(string input, int inputIndex)
        {
            var headerLevel = GetHeaderLevel(input, inputIndex);
            var headerToken = AbstractReader.Read(input, inputIndex + headerLevel, '\n');
            headerToken.Tag = TokenType.Header;
            headerToken.TagLevel = headerLevel;
            return headerToken;
        }

        private int GetHeaderLevel(string input, int inputIndex)
        {
            var headerLevel = 0;
            while (inputIndex != input.Length &&
                   input[inputIndex] == MarkdownSymbols.Header)
            {
                headerLevel++;
                inputIndex++;
            }
            return headerLevel;
        }
    }
}