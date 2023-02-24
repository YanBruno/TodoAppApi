using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Repositories;

namespace TodoApp.Infra.Src.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    public Task<bool> ChangeTodoList(Customer customer, TodoList todoList, TodoList newTodoList, TodoItem todoItemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(Customer customer, TodoList todoList, TodoItem todoItemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Customer customer, TodoList todoList, TodoItem todoItemId)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> GetByIdAsync(Customer customer, TodoList todoList, Guid? todoItem)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Customer customer, TodoList todoList, TodoItem todoItemId)
    {
        throw new NotImplementedException();
    }
}
