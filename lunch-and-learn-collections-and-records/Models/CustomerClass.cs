namespace lunch_and_learn_collections_and_records.Models;

public class CustomerClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CustomerClass(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}