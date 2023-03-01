using TodoApp.Core.Src.Entities.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Entities;
public class Customer : Entity
{
    private readonly IList<TodoList> lists;

    public Customer(Guid? id, DateTime? createAt, Name name, Email email, Phone phone, Password password) : base(id, createAt)
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        lists = new List<TodoList>();

        AddNotifications(Name, Email, Password, Phone);
    }

    public Name Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public IReadOnlyCollection<TodoList> Lists => (IReadOnlyCollection<TodoList>)lists;

    public void AddTodoLists(params TodoList[] lists)
    {
        lists.ToList().ForEach(
            l => AddTodoList(l)
        );
    }

    public void AddTodoList(TodoList todoList)
    {
        lists.Add(todoList);
    }

    public void RemoveTodoLists(params TodoList[] lists)
    {
        lists.ToList().ForEach(
            l => RemoveTodoList(l)
        );
    }

    public void RemoveTodoList(TodoList todoList)
    {
        lists.Remove(todoList);
    }

    public void UpdateName(Name name)
    {
        Name = name;
        AddNotifications(Name);
    }
}