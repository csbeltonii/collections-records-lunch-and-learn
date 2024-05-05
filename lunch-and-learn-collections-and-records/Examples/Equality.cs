using lunch_and_learn_collections_and_records.Models;

namespace lunch_and_learn_collections_and_records.Examples;

public class Equality
{
    public void CheckReferenceBasedEquality()
    {
        var customerA = new CustomerClass("Craig", "Belton");
        var customerB = customerA;
        var customerC = new CustomerClass("Craig", "Belton");

        Console.WriteLine("Checking for Reference based equality...");
        Console.WriteLine($"A == B ? {customerA == customerB}");
        Console.WriteLine($"A == C ? {customerA == customerC}");
        WriteExampleDivider();
    }

    public void CheckValueTypeEquality()
    {
        var customerA = new CustomerRecord("Craig", "Belton");
        var customerB = new CustomerRecord("Craig", "Belton");

        Console.WriteLine("Checking for Value based equality...");
        Console.WriteLine($"A == B ? {customerA == customerB}");
        WriteExampleDivider();
    }

    public void CheckRecordWithListEquality()
    {
        var names = new List<string>
        {
            "Crige",
            "Creg",
            "Greg",
            "Fred"
        };

        var customerA = new MultipleNickNamedCustomer(
            "Craig",
            "Belton",
            names
        );

        var customerB = new MultipleNickNamedCustomer(
            "Craig",
            "Belton",
            new List<string>
            {
                "Crige",
                "Creg",
                "Greg",
                "Fred"
            }
        );

        var customerC = new MultipleNickNamedCustomer(
            "Craig",
            "Belton",
            names
        );

        Console.WriteLine("Checking record equality with Lists");
        Console.WriteLine($"A == B ? {customerA == customerB}");
        Console.WriteLine($"A == C ? {customerA == customerC}");
        WriteExampleDivider();
    }

    public void CheckNestedRecordEquality()
    {
        var customerA = new NickNamedCustomer("Craig", "Belton", "Crayg");
        var customerB = new NickNamedCustomer("Craig", "Belton" , "Crayg");

        Console.WriteLine("Checking record equality with nested record.");
        Console.WriteLine($"A == B ? {customerA == customerB}");
        WriteExampleDivider();
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