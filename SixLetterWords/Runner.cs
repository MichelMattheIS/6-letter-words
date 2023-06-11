using SixLetterWords.Services;

namespace SixLetterWords;

public class Runner
{
    private readonly IWordProvider _wordProvider;
    private readonly ICombinationFinder _combinationFinder;

    public Runner(IWordProvider wordProvider, ICombinationFinder combinationFinder)
    {
        _wordProvider = wordProvider;
        _combinationFinder = combinationFinder;
    }

    public void Run(int combinationLength = 6)
    {
        var words = _wordProvider.GetAllWords();
        var combinations = _combinationFinder.FindAllCombinations(words, combinationLength);
        foreach (var combination in combinations)
        {
            Console.WriteLine(combination.Combined());
        }
    }
}