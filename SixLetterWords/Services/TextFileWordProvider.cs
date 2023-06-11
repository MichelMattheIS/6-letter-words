namespace SixLetterWords.Services;

public class TextFileWordProvider : IWordProvider
{
    private readonly string _filePath;
    public TextFileWordProvider(string filePath)
    {
        _filePath = filePath;
    }
    
    public IEnumerable<string> GetAllWords()
    {
        // File.ReadLines -> returns iterator, doesn't instantly read the entire thing and store it in memory
        //      File.ReadAllLines -> returns filled array of all lines as you would expect
        // This way only allows text files containing words separated by newlines, using File.ReadAllText and splitting it
        //    manually makes it more configurable, however, this is less efficient.
        return File.ReadLines(_filePath);
    }
}