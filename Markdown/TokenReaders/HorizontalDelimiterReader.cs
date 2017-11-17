
namespace Markdown.TokenReaders
{
    public class HorizontalDelimiterReader : IReader
    {
        public char Symbol { get; } = MarkdownSymbols.Asterisk;
        public Token Read(string input, int inputIndex)
        {
            if (CheckFullSymbol(input, inputIndex))
            {
                var token = AbstractReader.Read(input, inputIndex + 3, '\n');
                token.Tag = TokenType.Horizontal;
                return token;
            }

            return AbstractReader.Read(input, inputIndex, MarkdownSymbols.AllSymbols);
        }

        private bool CheckFullSymbol(string input, int inputIndex)
        {
            return inputIndex + 2 <= input.Length - 1 && input[inputIndex + 1] == MarkdownSymbols.Asterisk &&
                   input[inputIndex + 2] == MarkdownSymbols.Asterisk;
        }
    }
}
