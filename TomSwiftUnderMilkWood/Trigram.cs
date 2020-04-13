using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TomSwiftUnderMilkWood
{
    public class Trigram
    {

        public Dictionary<string, List<string>> BuildTrigram(string startingString)
        {
            Dictionary<string, List<string>> trigramStruct = new Dictionary<string, List<string>>();
            var startingIndex = 0;
            
            while (1==1)
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

        public string BuildRandomReturnString(Dictionary<string, List<string>> trigramStruct)
        {
            var value = string.Empty;
            KeyValuePair<string, List<string>> keyValuePair = GetRandomKeyValuePair(trigramStruct);
            var key = keyValuePair.Key;
            var returnString = key;

            do
            {
                value = GetRandomValueFromKeyValuePair(key, trigramStruct);

                if (!string.IsNullOrWhiteSpace(value))
                {
                    returnString += " " + value;

                    key = key.Substring(key.LastIndexOf(' ') + 1) + " " + value;
                }


            } while (!string.IsNullOrEmpty(value));

            return returnString.Trim(" ".ToCharArray());
        }

        public (string key,string value) FindWords(string workingString, int wordsToSkip)
        {
            var keyReturn = (string.Empty,string.Empty);

            var listOfWords = workingString.Split(" ".ToCharArray()).ToList();

            var twoWords = listOfWords.Skip(wordsToSkip).Take(2);
            var oneWord = listOfWords.Skip(2+wordsToSkip).Take(1);

            if (twoWords.Count().Equals(2) && oneWord.Count().Equals(1))
            {
                keyReturn = (string.Join(" ", twoWords), string.Join(" ", oneWord));
            }
            return keyReturn;
        }

        public KeyValuePair<string, List<string>> GetRandomKeyValuePair(Dictionary<string, List<string>> trigramStruct)
        {
            Random random = new Random();
            int index = random.Next(trigramStruct.Count);

           return trigramStruct.ElementAt(index);

        }

        public string GetRandomValueFromKeyValuePair(string key, Dictionary<string, List<string>> trigramStruct)
        {

            Random random = new Random();
            if (!trigramStruct.ContainsKey(key))
            {
                return string.Empty;
            }
            var valueList = trigramStruct[key];
            int index = random.Next(valueList.Count);

            var value = valueList.ElementAt(index);

            RemoveValueAndKey(key, trigramStruct, valueList, index);

            return value;

        }

        private static void RemoveValueAndKey(string key, Dictionary<string, List<string>> trigramStruct, List<string> valueList, int index)
        {
            valueList.RemoveAt(index);
            if (valueList.Count().Equals(0))
            {
                trigramStruct.Remove(key);
            }
            else
            {
                trigramStruct[key] = valueList;
            }
        }
    }
}
