using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using lunch_and_learn_collections_and_records.Models;

namespace lunch_and_learn_collections_and_records.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CollectionAccess
{
    [Benchmark]
    public void GetFirstCustomerUsingLinqFirst()
    {
        var customer = GetCustomers().First();
    }

    [Benchmark]
    public void GetLastCustomerUsingLinqLast()
    {
        var customer = GetCustomers().Last();
    }

    [Benchmark]
    public void GetFirstCustomerUsingListIndex()
    {
        var customer = GetCustomers().ToList()[0];
    }

    [Benchmark]
    public void GetLastCustomerUsingListIndex()
    {
        var customer = GetCustomers().ToList()[99];
    }

    [Benchmark]
    public void GetFirstCustomerUsingArrayAccess()
    {
        var customer = GetCustomers().ToArray()[0];
    }

    [Benchmark]
    public void GetLastCustomerUsingArrayAccess()
    {
        var customer = GetCustomers().ToArray()[99];
    }

    [Benchmark]
    public void GetFirstCustomerFromDictionary()
    {
        var customer = GenerateDictionary()[100];
    }

    [Benchmark]
    public void GetLastCustomerFromDictionary()
    {
        var customer = GenerateDictionary()[1];
    }

    private IEnumerable<CustomerClass> GetCustomers()
    {
        var count = 100;

        do
        {
            yield return new CustomerClass("Customer", $"{count}");
            count--;
        } while ( count > 0 );
    }

    private Dictionary<int, CustomerClass> GenerateDictionary()
    {
        var count = 100;
        var dictionary = new Dictionary<int, CustomerClass>();

        do
        {
            dictionary.Add(count, new CustomerClass("Customer", $"{count}"));
            count--;

        } while (count > 0 );

        return dictionary;
    }
}