namespace SixLetterWords.Models;

// Not so sure if this is a useful abstraction/ encapsulation or if simply using a list of strings was good enough
public class Combination
{
    public IEnumerable<string> Words { get; set; }
    public string Combined { get; set; }
}