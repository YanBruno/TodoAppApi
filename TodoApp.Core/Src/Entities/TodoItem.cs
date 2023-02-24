using TodoApp.Core.Src.Entities.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Entities;
public class TodoItem : Entity
{
    public TodoItem(Guid? id, DateTime? createAt, Title title, Note note, bool done) : base(id, createAt)
    {
        Title = title;
        Note = note;
        Done = done;

        AddNotifications(Title, Note);
    }

    public Title Title { get; private set; } = null!;
    public Note Note { get; private set; } = null!;
    public bool Done { get; private set; }

    public void UpdateTitle(Title title)
    {
        Title = title;
        AddNotifications(Title);
    }

    public void UpdateNote(Note note)
    {
        Note = note;
        AddNotifications(Note);
    }

    public void UpdateDone()
    {
        Done = !Done;
    }
}