using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Repositories;

namespace TodoApp.Infra.Src.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        public Task<bool> CreateAsync(Guid customerId, TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid customerId, Guid todoListId)
        {
            throw new NotImplementedException();
        }

        public Task<TodoList> GetByIdAsync(Guid customerId, Guid todoListId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid customerId, TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
