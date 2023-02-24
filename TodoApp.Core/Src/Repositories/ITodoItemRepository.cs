using TodoApp.Core.Src.Entities;

namespace TodoApp.Core.Src.Repositories;

public interface ITodoItemRepository
{
    Task<bool> DeleteAsync(Customer customer, TodoList todoList, TodoItem todoItemId);
    Task<bool> UpdateAsync(Customer customer, TodoList todoList, TodoItem todoItemId);
    Task<bool> ChangeTodoList(Customer customer, TodoList todoList, TodoList newTodoList, TodoItem todoItemId);
    Task<bool> CreateAsync(Customer customer, TodoList todoList, TodoItem todoItemId);
    Task<TodoItem> GetByIdAsync(Customer customer, TodoList todoList, Guid? todoItem);
}