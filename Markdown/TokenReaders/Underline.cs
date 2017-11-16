using System.Collections.Generic;
using Markdown.Readers;
using Markdown.TokenReaders;

namespace Markdown.Parsers
{
    public class Underline : CommonReaderEnviron, IRead
    {
        public char Symbol { get; } = MarkdownSymbols.Emphasis;
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
            if (input[inputIndex + 1] == MarkdownSymbols.Space)
                return GetTokenWithoutTags(input, startIndex, MarkdownSymbols.Emphasis, 1);
            inputIndex += 1;

            inputIndex = GetTagIndexWithTrueEnviron(input, inputIndex, CheckSingleTagEnviron);
            if (inputIndex == -1)
                return GetTokenWithoutTags(input, startIndex, MarkdownSymbols.Emphasis, 1);

            var fullToken = AbstractReader.Read(input, startIndex + 1, MarkdownSymbols.Emphasis);
            var resToken = new Token(input.Substring(fullToken.StartIndex, inputIndex - fullToken.StartIndex), startIndex + 2);
            if (resToken.Text[resToken.Text.Length - 1] == MarkdownSymbols.Space)
                return new Token(MarkdownSymbols.Emphasis + fullToken.Text, startIndex);

            var newStr = new Md(new List<IRead>()).RenderToHtml(resToken.Text);
            var token = new Token(newStr, startIndex + 2);
            token.Tag = token.TokenTypes["Italic"];
            return token;
        }

        private Token ReadDouble(string input, int inputIndex)
        {
            var startIndex = inputIndex;
            inputIndex += 2;

            inputIndex = GetTagIndexWithTrueEnviron(input, inputIndex, CheckDoubleTagEnviron);
            if (inputIndex == -1)
                return GetTokenWithoutTags(input, 0, MarkdownSymbols.Emphasis, 2);

            var resToken = new Token(input.Substring(startIndex + 2,
                inputIndex - startIndex - 2), startIndex + 4);
            var newStr = new Md().RenderToHtml(resToken.Text);
            var token = new Token(newStr, resToken.StartIndex);
            token.Tag = token.TokenTypes["Bold"];
            return token;
        }

        private bool CheckSingleTagEnviron(string input, int inputIndex)
        {
            return (inputIndex == input.Length || inputIndex + 1 != input.Length && input[inputIndex] == '_' &&
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
