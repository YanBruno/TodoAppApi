using Flunt.Notifications;
using Flunt.Validations;

namespace TodoApp.Core.Src.ValueObjects.Contracts;

public class CreateNameContract : Contract<Notification>
{
    public CreateNameContract(Name name)
    {
        Requires()
        .IsGreaterOrEqualsThan(name.FirstName.Length, 3, "Name.FirstName")
        .IsGreaterOrEqualsThan(name.LastName.Length, 3, "Name.LastName")
        ;
    }
}
