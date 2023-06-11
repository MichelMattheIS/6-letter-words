namespace SixLetterWords.Test;

public class CombinationTest
{
    [Test]
    public void TestIsAnagram()
    {
        var words = new List<string>
        {
            "fo",
            "o",
            "bar"
        };
        // all possible correct combinations:
        // "fo" "o" "bar"
        // "fo" "bar" "o"
        // "bar" "fo" "o"
        // "bar" "o" "fo"
        // "o" "fo" "bar"
        // "o" "bar" "fo"
        var combination = new Combination(words);
        var allPossiblePermutations = new List<string>
        {
            "foobar", "fobaro",
            "barfoo", "barofo",
            "ofobar", "obarfo"
        };
        foreach (var anagram in allPossiblePermutations)
        {
            combination.IsPermutation(anagram).Should().BeTrue();
        }

        // test to see if other anagrams that aren't permutations of the list of words don't return true
        combination.IsPermutation("oofbar").Should().BeFalse();
        combination.IsPermutation("oofbra").Should().BeFalse();
        combination.IsPermutation("ofobra").Should().BeFalse();
        combination.IsPermutation("oforab").Should().BeFalse();
    }
}