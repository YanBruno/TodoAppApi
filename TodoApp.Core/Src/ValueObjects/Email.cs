using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; private set; } = null!;

    public Email(string address)
    {
        Address = address;

        AddNotifications(new CreateEmailContract(this));
    }

    public Email()
    {
    }
}