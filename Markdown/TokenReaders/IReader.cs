
namespace Markdown.TokenReaders
{
    public interface IReader
    {
        char Symbol { get; }
        Token Read(string input, int inputIndex);
    }
}
