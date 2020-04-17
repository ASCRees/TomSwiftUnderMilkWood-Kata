using System.Collections.Generic;

namespace TomSwiftUnderMilkWood.Interfaces
{
    public interface ITrigramGenerator
    {
        Dictionary<string, List<string>> BuildTrigram(string startingString);
        (string key, string value) FindWords(string workingString, int wordsToSkip);
    }
}