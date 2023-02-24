using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects;

public class Name : ValueObject
{
    public Name()
    {
    }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new CreateNameContract(this));
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
}