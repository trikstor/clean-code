namespace Markdown
{
    public class Condition
    {
        public MarkdownSymbols Symbol { get; }
        public bool Equality { get; }

        public Condition(MarkdownSymbols currChar, bool equality)
        {
            Symbol = currChar;
            Equality = equality;
        }
        public Condition()
        {
        }
    }
}
