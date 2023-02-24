using Flunt.Notifications;
using Flunt.Validations;

namespace TodoApp.Core.Src.ValueObjects.Contracts;

public class CreateTitleContract : Contract<Notification>
{
    public CreateTitleContract(Title title)
    {
        Requires()
        .IsGreaterOrEqualsThan(title.Value.Length, 3, "Title.Value")
        ;
    }
}
