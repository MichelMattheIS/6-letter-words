namespace SixLetterWords.Services;

public interface IWordProvider
{
    IEnumerable<string> GetAllWords();
}