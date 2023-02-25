using TodoApp.Core.Src.Entities;

namespace TodoApp.Core.Src.Repositories;

public interface ITodoListRepository
{
    Task<bool> DeleteAsync(Customer customer, Guid todoListId);
    Task<bool> UpdateAsync(Customer customer, TodoList todoList);
    Task<bool> CreateAsync(Customer customer, TodoList todoList);
    Task<TodoList> GetByIdAsync(Customer customer, Guid todoListId);
    Task<IEnumerable<TodoList>> GetAllAsync(Guid customerId);
}