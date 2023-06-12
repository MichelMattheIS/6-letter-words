namespace SixLetterWords.Models;

// Not so sure if this is a useful abstraction/ encapsulation or if simply using a list of strings was good enough
public class Combination
{
    public string TodoDeleteLater { get; set; }
    public IList<string> Words { get;}

    public Combination(IList<string> words)
    {
        Words = words;
    }
    
    public Combination(IList<string> words, string todoDeleteLater)
    {
        Words = words;
        TodoDeleteLater = todoDeleteLater;
    }

    public string Combined()
    {
        return String.Join("", Words);
    }

    public bool IsPermutation(string word)
    {
        if (Combined().Length != word.Length) return false;
        return IsPermutation(Words, word);

        bool IsPermutation(IList<string> combination, string word)
        {
            if (String.Join("", combination) == word) return true; 
            for (int i = 0; i < combination.Count; i++)
            {
                var currentWord = combination[i];
                if (word.StartsWith(currentWord))
                {
                    var newList = new List<string>(combination);
                    newList.RemoveAt(i);
                    var newWord = word.Substring(currentWord.Length);
                    if (IsPermutation(newList, newWord)) return true;
                }
            }

            return false;
        }
    }

    public override string ToString()
    {
        return $"[{TodoDeleteLater}] {Combined()}={string.Join("+", Words)}";
    }
}