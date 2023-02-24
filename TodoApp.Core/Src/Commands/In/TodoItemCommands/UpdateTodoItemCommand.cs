using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoItemCommands;

public class UpdateTodoItemCommand : ICommand
{
    public Guid? TodoItemId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? TodoListId { get; set; }
    public string Title { get; set; } = null!;
    public string Note { get; set; } = null!;

    public bool IsValid()
    {
        return true;
    }
}