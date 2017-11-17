
namespace Markdown.TokenReaders
{
    public class CommonReaderEnviron
    {
       public Token GetTokenWithoutTags(string input, int inputIndex, char stopSymbol, int stopSymbolQuant)
        {
            var refund = "";
            for (var quantApended = 0; quantApended < stopSymbolQuant; quantApended++)
                refund += stopSymbol;
            var startToken = AbstractReader.Read(input, inputIndex + stopSymbolQuant, MarkdownSymbols.Emphasis);
            return new Token(refund + startToken.Text, inputIndex);
        }

        public delegate bool EnvironChecker(string input, int inputIndex);

        public int GetTagIndexWithTrueEnviron(string input, int inputIndex, EnvironChecker checker)
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
    }
}
