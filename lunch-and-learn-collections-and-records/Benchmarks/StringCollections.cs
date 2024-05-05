using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class StringCollections
{
    [Benchmark]
    public void RunGenerateStringCollection()
    {
        var list = GenerateStringCollection();
    }

    [Benchmark]
    public void RunGenerateStringList()
    {
        var list = GenerateStringList();
    }

    private StringCollection GenerateStringCollection()
    {
        var stringCollection = new StringCollection();

        for (int i = 0; i < 10000; i++)
        {
            stringCollection.Add($"Item {i}");
        }

        return stringCollection;
    }

    private List<string> GenerateStringList()
    {
        var list = new List<string>();

        for (int i = 0; i < 10000; i++)
        {
            list.Add($"Item {i}");
        }

        return list;
    }
}