namespace lunch_and_learn_collections_and_records.Models;

public record NickNamedCustomer(string FirstName, string LastName, string Nickname) 
    : CustomerRecord(FirstName, LastName);