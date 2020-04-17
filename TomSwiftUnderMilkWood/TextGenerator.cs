using System;
using System.Collections.Generic;
using System.Linq;
using TomSwiftUnderMilkWood.Interfaces;

namespace TomSwiftUnderMilkWood
{
    public class TextGenerator : ITextGenerator
    {
        public string BuildRandomReturnString(Dictionary<string, List<string>> trigramStruct, string returnString)
        {
            var value = string.Empty;
            KeyValuePair<string, List<string>> keyValuePair = GetRandomKeyValuePair(trigramStruct);
            var key = keyValuePair.Key;
            returnString += " " + key;
            if (trigramStruct.Count() > 0)
            {
                do
                {
                    value = GetRandomValueFromKeyValuePair(key, trigramStruct);
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        returnString += " " + value;
                        key = key.Substring(key.LastIndexOf(' ') + 1) + " " + value;
                    }
                } while (!string.IsNullOrEmpty(value));

                return BuildRandomReturnString(trigramStruct, returnString);
            }
            return returnString.Trim(" ".ToCharArray());
        }

        public KeyValuePair<string, List<string>> GetRandomKeyValuePair(Dictionary<string, List<string>> trigramStruct)
        {
            if (trigramStruct.Count == 0)
            {
                return new KeyValuePair<string, List<string>>();
            }
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