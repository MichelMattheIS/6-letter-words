using SixLetterWords.Models;

namespace SixLetterWords.Services;

public interface ICombinationFinder
{
    IEnumerable<Combination> FindAllCombinations(IReadOnlyCollection<string> words, int combinationLength);
}