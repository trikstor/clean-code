namespace Markdown
{
    public interface IReplaceable
    {
        char Symbol { get; }
        Environ EnvironOfReplace { get; }
        string[] Substitute { get; }

        void Replace(ref string inputOutput, int indexOfsymbol);
    }
}
