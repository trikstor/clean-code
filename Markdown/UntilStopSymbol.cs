using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public static class UntillStopSymbol
    {
        public static Token Parse(string input, int inputIndex, char stopSymbol)
        {
            var res = "";
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
                res += input[inputIndex];
            }
            return new Token(res, startIndex + deleted);
        }

        public static Token Parse(string input, int inputIndex, List<char> stopSymbols)
        {
            var startIndex = inputIndex;
            for (; inputIndex < input.Length; inputIndex++)
            {
                if (stopSymbols.Contains(input[inputIndex]))
                    break;
            }
            return new Token(input.Substring(startIndex, inputIndex - startIndex), startIndex);
        }
    }
}
