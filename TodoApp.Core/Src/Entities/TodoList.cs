using TodoApp.Core.Src.Entities.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Entities;
public class TodoList : Entity
{
    private readonly IList<TodoItem> todos;

    public TodoList(Guid? id, DateTime? createAt, Title title) : base(id, createAt)
    {
        Title = title;
        todos = new List<TodoItem>();
    }

    public Title Title { get; private set; } = null!;
    public IReadOnlyCollection<TodoItem> Todos => (IReadOnlyCollection<TodoItem>)todos;

    public void DeleteTodoItem(TodoItem todoItem)
    {
        todos.Remove(todoItem);
    }
    public void AddTodoItem(TodoItem todoItem)
    {
        todos.Add(todoItem);
    }

    public void UpdateTitle(Title title)
    { 
        Title = title;
    }
}