using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoItemCommands
{
    public class UpdateTodoItemDoneCommand : ICommand
    {
        public Guid? TodoItemId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TodoListId { get; set; }
        public bool Done { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
