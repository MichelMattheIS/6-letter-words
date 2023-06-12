namespace SixLetterWords.Models;

// Not so sure if this is a useful abstraction/ encapsulation or if simply using a list of strings was good enough
public class Combination
{
    public IList<string> Words { get;}

    public Combination(IList<string> words)
    {
        Words = words;
    }

    public string Combined()
    {
        return String.Join("", Words);
    }

    public override string ToString()
    {
        return $"{Combined()}={string.Join("+", Words)}";
    }
}