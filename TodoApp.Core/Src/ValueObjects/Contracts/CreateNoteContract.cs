using Flunt.Notifications;
using Flunt.Validations;

namespace TodoApp.Core.Src.ValueObjects.Contracts;

public class CreateNoteContract : Contract<Notification>
{
    public CreateNoteContract(Note note)
    {
        Requires()
        .IsGreaterOrEqualsThan(note.Value.Length, 3, "Note.Value")
        ;
    }
}
