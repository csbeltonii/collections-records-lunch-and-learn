using System.Collections.Specialized;

namespace lunch_and_learn_collections_and_records.Examples;

public class StringCollectionEquality
{
    public void TestStringCollectionEquality()
    {
        var camelCase = "isEqual";
        var pascalCase = "IsEqual";
        var weirdCase = "iSeQuAl";
        var controlCase = "isequal";

        var dictionary = new Dictionary<string, StringCollection>()
        {

            {
                "Pascal Case", 
                new StringCollection
                {
                    pascalCase
                }
            },
            {
                "Camel Case",
                new StringCollection
                {
                    camelCase
                }
            },
            {
                "Weird Case",
                new StringCollection
                {
                    weirdCase
                }
            }
        };


        foreach (var (casing, collection) in dictionary)
        {
            Console.WriteLine($"Does {casing} contain {controlCase}? {collection.Contains(controlCase)}");
        }
    }
}