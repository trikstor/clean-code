namespace Markdown
{
    public interface IReplaceable
    {
        char Symbol { get; }
        Environ EnvironOfReplace { get; }
        string[] Substitute { get; }

        string Replace(string input, int indexOfsymbol);
    }
}
