using System.Collections.Generic;
using System.Text;

namespace Markdown.TokenReaders
{
    public static class AbstractReader
    {
        public static Token Read(string input, int inputIndex, char stopSymbol)
        {
            var result = new StringBuilder();
            var deleted = 0;
            var startIndex = inputIndex;
            for (; inputIndex < input.Length; inputIndex++)
            {
                if (input[inputIndex] == stopSymbol)
                    break;
                if (input[inputIndex] == '\\')
                {
                    inputIndex += 1;
                    deleted++;
                }
                result.Append(input[inputIndex]);
            }
            return new Token(result.ToString(), startIndex + deleted);
        }

        public static Token Read(string input, int inputIndex, List<char> stopSymbols)
        {
            var result = new StringBuilder();
            var deleted = 0;
            var startIndex = inputIndex;
            for (; inputIndex < input.Length; inputIndex++)
            {
                if (stopSymbols.Contains(input[inputIndex]))
                    break;
                if (input[inputIndex] == '\\')
                {
                    inputIndex += 1;
                    deleted++;
                }
                result.Append(input[inputIndex]);
            }
            return new Token(result.ToString(), startIndex + deleted);
        }
    }
}
