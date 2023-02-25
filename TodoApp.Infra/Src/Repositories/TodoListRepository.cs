using Dapper;
using System.Data;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results;
using TodoApp.Core.Src.Repositories;
using TodoApp.Infra.Src.DataContext.Contracts;
using TodoApp.Infra.Src.Scripts.SqliteScripts;

namespace TodoApp.Infra.Src.Repositories
{
    public class TodoListRepository : DefaultConnection, ITodoListRepository
    {
        public async Task<bool> CreateAsync(Customer customer, TodoList todoList)
        {
            var result = await context.Connection.ExecuteAsync(
                SqliteGenericScripts.InsertTodoList
                , new
                {
                    todoList.Id
                    , customerId = customer.Id
                    , todoList.Title.Value
                    , todoList.CreateAt
                }
                , commandType: CommandType.Text
            );

            if (result == 0) return false;

            return true;
        }

        public Task<bool> DeleteAsync(Customer customer, Guid todoListId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoList>> GetAllAsync(Guid customerId)
        {
            var result = await context
                .Connection
                .QueryAsync<TodoListQueryResult>(
                    SqliteGenericScripts.GetTodoLists
                    , new { customerId }
                    , commandType: CommandType.Text
                );

            var todoLists = new List<TodoList>();

            foreach (var todoList in result)
            {
                todoLists.Add(todoList.ToEntity());
            }
            return todoLists;
        }

        public Task<TodoList> GetByIdAsync(Customer customer, Guid todoListId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Customer customer, TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
