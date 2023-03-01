using TodoApp.Core.Src.Entities;

namespace TodoApp.Core.Src.Repositories;

public interface ITodoItemRepository
{
    Task<bool> DeleteAsync(Customer customer, TodoList todoList, TodoItem todoItem);
    Task<bool> UpdateAsync(Customer customer, TodoList todoList, TodoItem todoItem);
    Task<bool> ChangeTodoList(Customer customer, TodoList todoList, TodoList newTodoList, TodoItem todoItem);
    Task<bool> CreateAsync(Customer customer, TodoList todoList, TodoItem todoItemId);
    Task<TodoItem> GetByIdAsync(Guid customerId, Guid todoListId, Guid todoItemId);
    Task<IEnumerable<TodoItem>> GetAllAsync(Guid customerId, Guid todoListId);
}