using SixLetterWords.Models;

namespace SixLetterWords.Services;

public class CombinationFinder : ICombinationFinder
{
    public IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words2, int combinationLength)
    {
        List<Combination> result = new List<Combination>();
        var words = words2.ToList(); // todo fix multiple enumeration error
        var possibleResults = words.Where(w => w.Length == combinationLength);

        foreach (var w in words.Where(w => w.Length < combinationLength))
        {
            var combinations = GetAllCombinations(w, words, combinationLength);
            foreach (var combination in combinations)
            {
                if (possibleResults.Contains(combination.Combined()))
                {
                    result.Add(combination);
                }
            }
        }

        return result;
    }
    
    List<Combination> GetAllCombinations(string word, List<string> words, int combinationLength)
    {
        List<Combination> result = words.Select(w => new Combination(new List<string>{w})).ToList();

        int currentMaxLength = combinationLength;
        while (currentMaxLength > 0)
        {
            var combinations = result.ToList().Where(c => c.Combined().Length + word.Length <= currentMaxLength)
                .Select(c => new Combination(c.Words.Append(word).ToList()));
            result.AddRange(combinations);
            currentMaxLength--;
        }

        return result;
    }

    // public IEnumerable<IEnumerable<string>> CartesianProduct(IEnumerable<IEnumerable<string>> sequences)
    // {
    //     IEnumerable<IEnumerable<string>> emptyProduct = new[] { Enumerable.Empty<string>() };
    //     return sequences.Aggregate(
    //         emptyProduct,
    //         (accumulator, sequence) =>
    //             from acc in accumulator
    //             from item in sequence
    //             select acc.Concat(new[] { item }));
    // }
}