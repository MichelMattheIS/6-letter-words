using SixLetterWords.Services;

namespace SixLetterWords.Test;

public class CombinationFinderTest
{
    private ICombinationFinder _combinationFinder;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _combinationFinder = new CombinationFinder();
    }

    [Test]
    public void Test1()
    {
        var words = new List<string>
        {
            "foobar",
            "foo",
            "app",
            "bar",
            "le",
            "s",
            "apples"
        };
        var combinations = _combinationFinder.FindAllCombinations(words, 6).ToList();
        combinations.Should().Contain(c => c.Combined == "foobar");
        combinations.Should().Contain(c => c.Combined == "apples");
        combinations.Count.Should().Be(2);
    }
}