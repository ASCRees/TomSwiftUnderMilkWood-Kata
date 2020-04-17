using System.Collections.Generic;

namespace TomSwiftUnderMilkWood.Interfaces
{
    public interface ITextGenerator
    {
        string BuildRandomReturnString(Dictionary<string, List<string>> trigramStruct, string returnString);
        KeyValuePair<string, List<string>> GetRandomKeyValuePair(Dictionary<string, List<string>> trigramStruct);
        string GetRandomValueFromKeyValuePair(string key, Dictionary<string, List<string>> trigramStruct);
    }
}