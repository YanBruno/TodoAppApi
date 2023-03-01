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
                SqliteTodoListScript.InsertTodoList
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

        public async Task<bool> DeleteAsync(Customer customer, Guid todoListId)
        {
           var result = await context
                .Connection
                .ExecuteAsync(
                    SqliteTodoListScript.DeleteTodoLists
                    , new {
                        customerId = customer.Id
                        , todoListId
                    }
                    , commandType: CommandType.Text
                );

            if (result > 0) return true;

            return false;
        }

        public async Task<IEnumerable<TodoList>> GetAllAsync(Guid customerId)
        {
            var result = await context
                .Connection
                .QueryAsync<TodoListQueryResult>(
                    SqliteTodoListScript.GetTodoLists
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

        public async Task<TodoList> GetByIdAsync(Guid customerId, Guid todoListId)
        {
            var result = await context
                .Connection
                .QueryFirstOrDefaultAsync<TodoListQueryResult>(
                    SqliteTodoListScript.GetTodoListById
                    , new { 
                        customerId
                        , todoListId
                    }
                    , commandType: CommandType.Text
                );

            if (result != null) return result.ToEntity();

            return null!;
        }

        public async Task<bool> UpdateAsync(Customer customer, TodoList todoList)
        {
            var result = await context
                .Connection
                .ExecuteAsync(
                    SqliteTodoListScript.UpdateTodoLists
                    , new {
                        customerId = customer.Id
                        , todoListId = todoList.Id
                        , todoList.Title.Value
                    }
                );

            if (result > 0) return true;

            return false;
        }
    }
}
