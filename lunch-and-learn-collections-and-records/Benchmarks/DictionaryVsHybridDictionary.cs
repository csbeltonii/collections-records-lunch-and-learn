using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DictionaryVsHybridDictionary
{
    [Benchmark]
    public void RunGenerateDictionary()
    {
        var dictionary = GenerateDictionary();
    }

    [Benchmark]
    public void RunHybridDictionary()
    {
        var dictionary = GenerateHybridDictionary();
    }

    private Dictionary<string, string> GenerateDictionary()
    {
        var dictionary = new Dictionary<string, string>();

        for (var i = 0; i < 10000; i++)
        {
            dictionary.Add($"{i}", $"Item {i}");
        }

        return dictionary;
    }

    private HybridDictionary GenerateHybridDictionary()
    {
        var hybridDictionary = new HybridDictionary();

        for (var i = 0; i < 50000; i++)
        {
            hybridDictionary.Add($"{i}", $"Item {i}");
        }

        return hybridDictionary;
    }
}