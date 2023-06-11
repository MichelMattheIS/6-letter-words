using SixLetterWords.Models;

namespace SixLetterWords.Services;

public class CombinationFinder : ICombinationFinder
{
    public IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words2, int combinationLength)
    {
        var words = words2.ToList(); // todo fix multiple enumeration error
        var possibleResults = words.Where(w => w.Length == combinationLength);

        foreach (var w in words.Where(w => w.Length < combinationLength))
        {
            var test = GetAllCombinations(w, words, combinationLength);
        }
        
        // var test2 = GetCartesianProduct(words, 2);
        // var test4 = GetCartesianProduct(words, 4);

        return new List<Combination>();
    }
    
    List<List<string>> GetAllCombinations(string word, List<string> words, int combinationLength)
    {
        // words.
        return words.Where(w => w.Length + word.Length < combinationLength)
            .Select(w => new List<string> { word, w }).ToList();
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