namespace Markdown
{
    public class Condition
    {
        public char Char { get; }
        public bool Equality { get; }

        public Condition(char currChar, bool equality)
        {
            Char = currChar;
            Equality = equality;
        }
        public Condition()
        {
        }
    }
}
