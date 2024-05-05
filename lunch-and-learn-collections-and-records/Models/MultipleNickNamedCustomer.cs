namespace lunch_and_learn_collections_and_records.Models;

public record MultipleNickNamedCustomer(string FirstName, string LastName, IEnumerable<string> NickNames)
    : CustomerRecord(FirstName, LastName);