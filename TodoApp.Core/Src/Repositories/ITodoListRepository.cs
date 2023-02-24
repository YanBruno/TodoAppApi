using TodoApp.Core.Src.Entities;

namespace TodoApp.Core.Src.Repositories;

public interface ITodoListRepository
{
    Task<bool> DeleteAsync(Guid customerId, Guid todoListId);
    Task<bool> UpdateAsync(Guid customerId, TodoList todoList);
    Task<bool> CreateAsync(Guid customerId, TodoList todoList);
    Task<TodoList> GetByIdAsync(Guid customerId, Guid todoListId);
}