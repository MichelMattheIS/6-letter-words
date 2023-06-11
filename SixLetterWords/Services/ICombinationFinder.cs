using SixLetterWords.Models;

namespace SixLetterWords;

public interface ICombinationFinder
{
    IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words, int combinationLength);
}