using System.Text.RegularExpressions;
using SixLetterWords.Models;

namespace SixLetterWords.Services;

public class CombinationFinder : ICombinationFinder
{
    public IEnumerable<Combination> FindAllCombinations(IEnumerable<string> words, int combinationLength)
    {
        var sixLetters = words.Where(s => s.Length == combinationLength).ToList();
        var lessThanSixLetters = words.Where(s => s.Length < combinationLength).ToList();
        List<Combination> result = new List<Combination>();
        foreach (string six in sixLetters)
        {
            string tmp = six;
            Combination combination = new Combination(new List<string>());
            int i = 0;
            while (i < lessThanSixLetters.Count)
            {
                var lessSix = lessThanSixLetters[i];
                if (tmp.StartsWith(lessSix))
                {
                    tmp = tmp.Substring(lessSix.Length);
                    var index = Math.Min(six.IndexOf(lessSix), combination.Words.Count);
                    // Console.WriteLine($"\nsix: {six} | lessSix: {lessSix} | tmp: {tmp} | index: {index}");
                    combination.Words.Insert(index, lessSix);
                    
                    if (string.IsNullOrEmpty(tmp))
                    {
                        result.Add(combination);
                        break;
                    }
                    
                    i = 0;
                }
                else i++;
            }
        }

        return result;
    }
}