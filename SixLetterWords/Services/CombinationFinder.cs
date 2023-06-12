using SixLetterWords.Models;

namespace SixLetterWords.Services;

public class CombinationFinder : ICombinationFinder
{
    public IEnumerable<Combination> FindAllCombinations(IReadOnlyCollection<string> words, int combinationLength)
    {
        var possibleCombinations = words.Where(s => s.Length == combinationLength).ToList();
        var combinableWords = words.Where(s => s.Length < combinationLength).ToList();
        List<Combination> result = new List<Combination>();
        foreach (string possibleCombination in possibleCombinations)
        {
            string remainingLetters = possibleCombination;
            Combination combination = new Combination(new List<string>());
            int i = 0;
            while (i < combinableWords.Count && !string.IsNullOrEmpty(remainingLetters))
            {
                var combinableWord = combinableWords[i];
                if (!remainingLetters.StartsWith(combinableWord))
                {
                    i++;
                    continue;
                }

                remainingLetters = remainingLetters.Substring(combinableWord.Length);
                combination.Words.Insert(combination.Words.Count, combinableWord);
                if (string.IsNullOrEmpty(remainingLetters)) result.Add(combination);
                i = 0;
            }
        }

        return result;
    }
}