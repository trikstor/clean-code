using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.ActiveElements;
using Markdown.Readers;

namespace Markdown.Parsers
{
    public class Underline : IReadable
    {
        private readonly Md singleMd = new Md(
            new List<TokenReader>
        {
        });

        public Token Read(string input, int inputIndex)
        {
            if (inputIndex + 1 > input.Length - 1)
                return new Token(input.Substring(inputIndex), inputIndex);
            if (char.IsDigit(input[inputIndex + 1]))
            {
                return new Token(
                    input[0] + AbstractReader.Read(input, inputIndex + 1, 
                    MarkdownSymbols.AllSymbols).Text,
                    inputIndex);
            }
            return input[inputIndex + 1] != MarkdownSymbols.Emphasis ? 
                ReadSingle(input, inputIndex) : ReadDouble(input, inputIndex);
        }

        private Token ReadSingle(string input, int inputIndex)
        {
            var startIndex = inputIndex;
            var startToken = AbstractReader.Read(input, inputIndex + 1, MarkdownSymbols.Emphasis);
            if (startToken.StartIndex + startToken.Text.Length == input.Length || 
                input[inputIndex + 1] == MarkdownSymbols.Space)
                return new Token('_' + startToken.Text, inputIndex);
            startToken.StartIndex += 1;

            var tempInput = inputIndex;
            inputIndex += 1;
            inputIndex = GetTagIndexWithTrueEnviron(input, inputIndex, CheckSingleTagEnviron);
            if (inputIndex == -1) return 
                    new Token(MarkdownSymbols.Emphasis + startToken.Text, tempInput);

            var resToken = new Token(input.Substring(startToken.StartIndex - 1, inputIndex - startToken.StartIndex + 1), tempInput + 2);
            if (resToken.Text[resToken.Text.Length - 1] == MarkdownSymbols.Space)
                return new Token('_' + startToken.Text, startIndex);

            var newStr = singleMd.RenderToHtml(resToken.Text);
            return new Token(newStr, tempInput + 2) {Type = Token.TokenType.Italic};
        }

        private Token ReadDouble(string input, int inputIndex)
        {
            var startInput = inputIndex;
            var startToken = AbstractReader.Read(input, inputIndex + 2, MarkdownSymbols.Emphasis);
            inputIndex += 2;
            inputIndex = GetTagIndexWithTrueEnviron(input, inputIndex, CheckDoubleTagEnviron);
            if (inputIndex == -1)
                return new Token("__" + startToken.Text, startInput);

            var resToken = new Token(input.Substring(startToken.StartIndex,
                inputIndex - startToken.StartIndex), startInput + 4);
            var newStr = new Md().RenderToHtml(resToken.Text);
            return new Token(newStr, resToken.StartIndex) { Type = Token.TokenType.Bold };
        }

        private delegate bool EnvironChecker(string input, int inputIndex);

        private int GetTagIndexWithTrueEnviron(string input, int inputIndex, EnvironChecker checker)
        {
            var found = false;
            for (; inputIndex < input.Length; inputIndex++)
            {
                if (!checker(input, inputIndex)) continue;
                found = true;
                break;
            }
            if (found)
                return inputIndex;
            return -1;
        }

        private bool CheckSingleTagEnviron(string input, int inputIndex)
        {
            return (inputIndex + 1 != input.Length && input[inputIndex] == '_' &&
                    input[inputIndex + 1] != '_' && input[inputIndex - 1] != '_') ||
                   (inputIndex + 1 == input.Length && input[inputIndex] == '_' &&
                    input[inputIndex - 1] != '_');
        }

        private bool CheckDoubleTagEnviron(string input, int inputIndex)
        {
            return (inputIndex < input.Length - 1 &&
                    input[inputIndex] == '_' && input[inputIndex + 1] == '_');
        }
    }
}
