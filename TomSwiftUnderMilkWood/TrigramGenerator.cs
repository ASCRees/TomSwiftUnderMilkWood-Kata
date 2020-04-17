using System.Collections.Generic;
using System.Linq;
using TomSwiftUnderMilkWood.Interfaces;

namespace TomSwiftUnderMilkWood
{
    public class TrigramGenerator : ITrigramGenerator
    {
        public Dictionary<string, List<string>> BuildTrigram(string startingString)
        {
            Dictionary<string, List<string>> trigramStruct = new Dictionary<string, List<string>>();
            var startingIndex = 0;

            while (1 == 1)
            {
                var foundKeyValue = FindWords(startingString, startingIndex);

                if (string.IsNullOrWhiteSpace(foundKeyValue.key))
                {
                    break;
                }

                if (trigramStruct.ContainsKey(foundKeyValue.key))
                {
                    trigramStruct[foundKeyValue.key].Add(foundKeyValue.value);
                }
                else
                {
                    trigramStruct.Add(foundKeyValue.key, new List<string>() { foundKeyValue.value });
                }

                startingIndex++;
            }

            return trigramStruct;
        }

        public (string key, string value) FindWords(string workingString, int wordsToSkip)
        {
            var keyReturn = (string.Empty, string.Empty);

            var listOfWords = workingString.Split(" ".ToCharArray()).ToList();

            var twoWords = listOfWords.Skip(wordsToSkip).Take(2);
            var oneWord = listOfWords.Skip(2 + wordsToSkip).Take(1);

            if (twoWords.Count().Equals(2) && oneWord.Count().Equals(1))
            {
                keyReturn = (string.Join(" ", twoWords), string.Join(" ", oneWord));
            }
            return keyReturn;
        }
    }
}