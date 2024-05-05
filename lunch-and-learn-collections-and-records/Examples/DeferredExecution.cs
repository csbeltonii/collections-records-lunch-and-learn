namespace lunch_and_learn_collections_and_records.Examples;

public class DeferredExecution
{
    public void UseIEnumerable()
    {
        var names = GetNames();

        var alphabeticalOrder = names.OrderBy(name => name);
        var reverseOrder = names.OrderByDescending(name => name);

        foreach (var name in alphabeticalOrder)
        {
            Console.WriteLine(name);
        }

        WriteExampleDivider();

        foreach (var name in reverseOrder)
        {
            Console.WriteLine(name);
        }

        WriteExampleDivider();
    }

    public void UseList()
    {
        var names = GetNames().ToList();

        var alphabeticalOrder = names.OrderBy(name => name);
        var reverseOrder = names.OrderByDescending(name => name);

        foreach (var name in alphabeticalOrder)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        foreach (var name in reverseOrder)
        {
            Console.WriteLine(name);
        }
    }

    public async Task UseIAsyncEnumerable()
    {
        var names = GetNamesAsync();

        await foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        WriteExampleDivider();

        var namesStartingWithA = names
                                 .ToBlockingEnumerable()
                                 .Where(name => name.StartsWith('A'));

        foreach (var name in namesStartingWithA)
        {
            Console.WriteLine(name);
        }

        WriteExampleDivider();
    }

    private async IAsyncEnumerable<string> GetNamesAsync()
    {
        yield return "Persephone";
        await Task.Delay(1000);

        yield return "Aphrodite";
        await Task.Delay(1000);

        yield return "Andromeda";
        await Task.Delay(1000);

        yield return "Athena";
        await Task.Delay(1000);
    }

    private IEnumerable<string> GetNames()
    {
        yield return "Craig";
        yield return "Oniel";
        yield return "Ron";
        yield return "Aasif";
    }

    private static void WriteExampleDivider()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();
    }
}