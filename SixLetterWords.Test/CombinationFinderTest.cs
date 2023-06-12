using SixLetterWords.Services;

namespace SixLetterWords.Test;

public class CombinationFinderTest
{
    private ICombinationFinder _combinationFinder = null!;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _combinationFinder = new CombinationFinder();
    }

    [Test]
    public void ShouldFindCombinations()
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
        combinations.Should().Contain(c => c.Combined() == "foobar");
        combinations.Should().Contain(c => c.Combined() == "apples");
        combinations.Count.Should().Be(2);
    }
    
    [Test]
    public void ShouldFindCombinations_WhenDeadEnds()
    {
        var words = new List<string>
        {
            "foobar",
            "foob",
            "foo",
            "app",
            "bar",
            "le",
            "s",
            "apples"
        };
        var combinations = _combinationFinder.FindAllCombinations(words, 6).ToList();
        combinations.Should().Contain(c => c.Combined() == "foobar");
        combinations.Should().Contain(c => c.Combined() == "apples");
        combinations.Count.Should().Be(2);
    }
    
    [Test]
    public void ShouldNotFindCombinations()
    {
        var words = new List<string>
        {
            "foobar",
            "foo",
            "app",
            "ba",
            "le",
            "apples"
        };
        var combinations = _combinationFinder.FindAllCombinations(words, 6).ToList();
        combinations.Count.Should().Be(0);
    }
}