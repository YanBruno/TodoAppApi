using Flunt.Notifications;
using Flunt.Validations;

namespace TodoApp.Core.Src.ValueObjects.Contracts;

public class CreateEmailContract : Contract<Notification>
{
    public CreateEmailContract(Email email)
    {
        Requires()
        .IsEmail(email.Address, "Email.Address")
        ;
    }
}
