using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using lunch_and_learn_collections_and_records.Models;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class YieldReturnVsAddRecords
{
    [Benchmark]
    public void RunRecordsWithYield()
    {
        var customers = GenerateRecordsWithYield();
    }

    [Benchmark]
    public void RunRecordsWithList()
    {
        var customers = GenerateRecordsWithList();
    }

    [Benchmark]
    public void RunRecordStructsWithYield()
    {
        var customers = GenerateStructsWithYield();
    }

    [Benchmark]
    public void RunRecordStructsWithLast()
    {
        var customers = GenerateStructsWithList();
    }

    private IEnumerable<CustomerRecord> GenerateRecordsWithYield()
    {
        for (var i = 0; i < 1000; i++)
        {
            yield return new CustomerRecord("Customer", $"{i}");
        }
    }

    private IEnumerable<CustomerRecord> GenerateRecordsWithList()
    {
        var list = new List<CustomerRecord>();

        for (var i = 0; i < 1000; i++)
        {
            list.Add(new CustomerRecord("Customer", $"{i}"));
        }

        return list;
    }

    private IEnumerable<CustomerRecordStruct> GenerateStructsWithYield()
    {
        for (var i = 0; i < 1000; i++)
        {
            yield return new CustomerRecordStruct("Customer", $"i");
        }
    }

    private IEnumerable<CustomerRecordStruct> GenerateStructsWithList()
    {
        var list = new List<CustomerRecordStruct>();

        for (var i = 0; i < 1000; i++)
        {
            list.Add(new CustomerRecordStruct("Customer", $"i"));
        }

        return list;
    }
}