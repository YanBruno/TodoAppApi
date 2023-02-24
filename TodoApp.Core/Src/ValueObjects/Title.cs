using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects;

public class Title : ValueObject
{
    public Title()
    {
    }

    public Title(string value)
    {
        Value = value;

        AddNotifications(new CreateTitleContract(this));
    }

    public string Value { get; private set; } = null!;
}