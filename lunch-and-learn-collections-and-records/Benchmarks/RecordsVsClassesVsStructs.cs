using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using lunch_and_learn_collections_and_records.Models;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class RecordsVsClassesVsStructs
{
    [Benchmark]
    public void CreateCustomerClass()
    {
        var customer = GenerateCustomerClass();
    }

    [Benchmark]
    public void CreateCustomerRecord()
    {
        var customer = GenerateCustomerRecord();
    }

    [Benchmark]
    public void CreateCustomerStruct()
    {
        var customer = GenerateCustomerStruct();
    }

    [Benchmark]
    public void CreateCustomerRecordStruct()
    {
        var customer = GenerateCustomerRecordStruct();
    }

    private CustomerClass GenerateCustomerClass() => new("Samwise", "Gamgee");

    private CustomerRecord GenerateCustomerRecord() => new("Samwise", "Gamgee");

    private CustomerStruct GenerateCustomerStruct() => new()
    {
        FirstName = "Samwise",
        LastName = "Gamgee"
    };

    private CustomerRecordStruct GenerateCustomerRecordStruct() => new("Samwise", "Gamgee");
}