using SixLetterWords.Models;

namespace SixLetterWords.Services;

public interface ICombinationFinder
{
    IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words, int combinationLength);
}