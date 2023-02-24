using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoItemCommands;

public class ChangeTodoItemFromTodoListCommand : ICommand
{
    public Guid? CustomerId { get; set; }
    public Guid? TodoItemId { get; set; }
    public Guid? TodoListId { get; set; }
    public Guid? NewTodoListId { get; set; }

    public bool IsValid()
    {
        return true;
    }
}