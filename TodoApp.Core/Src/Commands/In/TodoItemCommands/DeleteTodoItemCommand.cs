using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoItemCommands;

public class DeleteTodoItemCommand : ICommand
{
    public Guid? TodoItemId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? TodoListId { get; set; }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}