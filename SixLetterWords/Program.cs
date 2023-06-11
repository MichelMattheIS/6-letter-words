
using SixLetterWords;

IWordProvider wordProvider = new TextFileWordProvider();
ICombinationFinder combinationFinder = new CombinationFinder();

var runner = new Runner(wordProvider, combinationFinder);
runner.Run();