using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoListCommands;

public class UpdateTodoListCommand : ICommand
{
    public Guid? TodoListId { get; set; }
    public Guid? CustomerId { get; set; }
    public string? Title { get; set; }

    public bool IsValid()
    {
        return true;
    }
}