using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoItemCommands
{
    public class MarkTodoItemDone : ICommand
    {
        public Guid? TodoItemId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TodoListId { get; set; }

        public bool IsValid() => true;
    }
}
