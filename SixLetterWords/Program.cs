
using SixLetterWords;
using SixLetterWords.Services;

IWordProvider wordProvider = new TextFileWordProvider("../../../Resources/input.txt");
ICombinationFinder combinationFinder = new CombinationFinder();

var runner = new Runner(wordProvider, combinationFinder);
runner.Run();