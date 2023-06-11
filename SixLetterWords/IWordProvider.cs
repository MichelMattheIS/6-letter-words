namespace SixLetterWords;

public interface IWordProvider
{
    IEnumerable<string> GetAllWords();
}