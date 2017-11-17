
namespace Markdown
{
    public class Token
    {
        public string Text { get; }
        public TokenType BlockTag { get; set; }
        public bool BlockOpen { get; set; }
        public bool BlockClose { get; set; }
        public TokenType Tag { get; set; }
        public int TagLevel { get; set; }
        public int StartIndex { get; set; } 

        public Token(string text, int stratIndex)
        {
            Text = text;
            BlockTag = TokenType.Default;
            BlockOpen = false;
            BlockClose = false;
            Tag = TokenType.Default;
            StartIndex = stratIndex;
        }

        public Token(string text, int stratIndex, bool blockOpen, bool blockClose)
        {
            Text = text;
            BlockTag = TokenType.Default;
            BlockOpen = blockOpen;
            BlockClose = false;
            Tag = TokenType.Default;
            StartIndex = stratIndex;
        }
    }
}
