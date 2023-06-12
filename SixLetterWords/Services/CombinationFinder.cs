using SixLetterWords.Models;

namespace SixLetterWords.Services;

public class CombinationFinder : ICombinationFinder
{
    public IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words, int combinationLength)
    {
        var sixLetters = words.Where(s => s.Length == combinationLength).ToList();
        var lessThanSixLetters = words.Where(s => s.Length < combinationLength).OrderByDescending(x => x.Length).ToList();
        List<Combination> result = new List<Combination>();
        foreach (string six in sixLetters)
        {
            string tmp = six;
            Combination combination = new Combination(new List<string>());
            foreach (string lessSix in lessThanSixLetters)
            {
                if (tmp.Contains(lessSix))
                {
                    tmp = tmp.Replace(lessSix, "");
                    combination.Words.Insert(six.IndexOf(lessSix), lessSix);
                }
                if (string.IsNullOrEmpty(tmp))
                {
                    result.Add(combination);
                    break;
                }
            }
        }

        return result;
    }
}