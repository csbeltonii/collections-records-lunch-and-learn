using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using lunch_and_learn_collections_and_records.Models;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class YieldReturnVsAdd
{
    [Benchmark]
    public void Generate100CustomersViaUnboundedList()
    {
        var customers = GenerateCustomersWithUnboundedList(100);
    }

    [Benchmark]
    public void Generate1000CustomersViaUnboundedList()
    {
        var customers = GenerateCustomersWithUnboundedList(1000);
    }

    [Benchmark]
    public void Generate10000CustomersViaUnboundedList()
    {
        var customers = GenerateCustomersWithUnboundedList(10000);
    }

    [Benchmark]
    public void Generate100CustomersViaBoundedList()
    {
        var customers = GenerateCustomersWithBoundedList(100);
    }

    [Benchmark]
    public void Generate1000CustomersViaBoundedList()
    {
        var customers = GenerateCustomersWithBoundedList(1000);
    }

    [Benchmark]
    public void Generate10000CustomersViaBoundedList()
    {
        var customers = GenerateCustomersWithBoundedList(10000);
    }

    [Benchmark]
    public void Generate100CustomersViaYield()
    {
        var customers = GenerateCustomersWithYield(100);
    }

    [Benchmark]
    public void Generate1000CustomersViaYield()
    {
        var customers = GenerateCustomersWithYield(1000);
    }

    [Benchmark]
    public void Generate10000CustomersViaYield()
    {
        var customers = GenerateCustomersWithYield(10000);
    }

    private IEnumerable<CustomerClass> GenerateCustomersWithUnboundedList(int count)
    {
        var list = new List<CustomerClass>();

        for (var i = 0; i < count; i++)
        {
            list.Add(new CustomerClass("Customer", $"{i}"));
        }

        return list;
    }

    private IEnumerable<CustomerClass> GenerateCustomersWithBoundedList(int count)
    {
        var list = new List<CustomerClass>(count);

        for (var i = 0; i < count; i++)
        {
            list.Add(new CustomerClass("Customer", $"{i}"));
        }

        return list;
    }

    private IEnumerable<CustomerClass> GenerateCustomersWithYield(int count)
    {
        while (count > 0)
        {
            yield return new CustomerClass("Customer", $"{count}");
        }
    }
}