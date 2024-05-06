using BenchmarkDotNet.Running;
using lunch_and_learn_collections_and_records.Benchmarks;
using lunch_and_learn_collections_and_records.Examples;
using Microsoft.VisualBasic;

var continueExecution = true;

while (continueExecution)
{
    Console.WriteLine("0: Exit demo.");
    Console.WriteLine("1. Deferred Execution");
    Console.WriteLine("2. Equality");
    Console.WriteLine("3. String Collection");
    Console.WriteLine("4. Hybrid Dictionary Benchmark");
    Console.WriteLine("5. Records vs Classes Benchmark");
    Console.WriteLine("6. Yield Return vs List.Add Benchmark");
    Console.WriteLine("7. String Collection Benchmark");
    Console.WriteLine("8. Records/Record Structs List Benchmark");
    Console.WriteLine("9. Collection access Benchmark");
    Console.WriteLine("");
    Console.Write("Select an example to run: ");

    var entry = Console.ReadKey().Key;
    Console.WriteLine("");

    switch (entry)
    {
        case ConsoleKey.D0:
            continueExecution = false;
            break;
        case ConsoleKey.D1:
            await RunDeferredExecutionExampleAsync();
            break;
        case ConsoleKey.D2:
            RunEqualityExample();
            break;
        case ConsoleKey.D3:
            RunStringCollectionExample();
            break;
        case ConsoleKey.D4:
            RunHybridDictionaryBenchmark();
            break;
        case ConsoleKey.D5:
            RunRecordsVsClassesBenchmark();
            break;
        case ConsoleKey.D6:
            RunYieldReturnBenchmark();
            break;
        case ConsoleKey.D7:
            RunStringCollectionBenchmark();
            break;
        case ConsoleKey.D8:
            RunYieldReturnRecordsBenchmark();
            break;
        case ConsoleKey.D9:
            RunCollectionAccessBenchmark();
            break;
    }

    Console.WriteLine();
}

void RunEqualityExample()
{
    var continueEqualityExample = true;
    var equality = new Equality();

    while (continueEqualityExample)
    {
        Console.WriteLine("Select an example to run");
        Console.WriteLine("0. Return to example selection.");
        Console.WriteLine("1. Reference based equality");
        Console.WriteLine("2. Value Type Equality");
        Console.WriteLine("3. Record with List Equality");
        Console.WriteLine("4. Record with Nested Record Equality");

        var entry = Console.ReadKey().Key;

        switch (entry)
        {
            case ConsoleKey.D0:
                continueEqualityExample = false;
                break;
            case ConsoleKey.D1:
                equality.CheckReferenceBasedEquality();
                break;
            case ConsoleKey.D2:
                equality.CheckValueTypeEquality();
                break;
            case ConsoleKey.D3:
                equality.CheckRecordWithListEquality();
                break;
            case ConsoleKey.D4:
                equality.CheckNestedRecordEquality();
                break;
        }
    }
}

async Task RunDeferredExecutionExampleAsync()
{
    var continueDeferredExecutionExample = true;
    var deferredExecution = new DeferredExecution();

    while (continueDeferredExecutionExample)
    {
        Console.WriteLine("Select an example to run");
        Console.WriteLine("0. Return to example selection.");
        Console.WriteLine("1. IEnumerable");
        Console.WriteLine("2. List");
        Console.WriteLine("3. IAsyncEnumerable");

        var entry = Console.ReadKey().Key;

        switch (entry)
        {
            case ConsoleKey.D0:
                continueDeferredExecutionExample = false;
                break;
            case ConsoleKey.D1:
                deferredExecution.UseIEnumerable();
                break;
            case ConsoleKey.D2:
                deferredExecution.UseList();
                break;
            case ConsoleKey.D3:
                await deferredExecution.UseIAsyncEnumerable();
                break;
        }
    }
}

void RunStringCollectionExample()
{
    var example = new StringCollectionEquality();

    example.TestStringCollectionEquality();
}

void RunStringCollectionBenchmark() => BenchmarkRunner.Run<StringCollections>();

void RunHybridDictionaryBenchmark() => BenchmarkRunner.Run<DictionaryVsHybridDictionary>();

void RunRecordsVsClassesBenchmark() => BenchmarkRunner.Run<RecordsVsClassesVsStructs>();

void RunYieldReturnBenchmark() => BenchmarkRunner.Run<YieldReturnVsAdd>();

void RunYieldReturnRecordsBenchmark() => BenchmarkRunner.Run<YieldReturnVsAddRecords>();

void RunCollectionAccessBenchmark() => BenchmarkRunner.Run<CollectionAccess>();