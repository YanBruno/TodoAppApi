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
                     SqliteTodoListScript.DeleteTodoList
                     , new
                     {
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
            var todoLists = new List<TodoList>();

            var result = await context
                .Connection
                .QueryAsync<TodoListQueryResult, TodoItemQueryResult, TodoListQueryResult>(
                    SqliteTodoListScript.GetTodoLists
                    , (todoListResult, todoItemResult) =>
                    {

                        var todoList = todoLists.FirstOrDefault(c => c.Id == Guid.Parse(todoListResult.todo_lista_id));
                        if (todoList == null)
                        {
                            todoList = todoListResult.ToEntity();
                            if (todoItemResult != null)
                            {
                                var todoItem = todoItemResult.ToEntity();
                                todoList.AddTodoItem(todoItem);
                            }
                            todoLists.Add(todoList);
                        }
                        else
                        {
                            if (todoItemResult != null)
                                todoList.AddTodoItem(todoItemResult.ToEntity());
                        }

                        return todoListResult;
                    }
                    , new { customerId }
                    , commandType: CommandType.Text
                    , splitOn: "todo_item_id"
                );

            return todoLists;
        }

        public async Task<TodoList> GetByIdAsync(Guid customerId, Guid todoListId)
        {
            var todoLists = new List<TodoList>();

            var result = await context
                .Connection
                .QueryAsync<TodoListQueryResult, TodoItemQueryResult, TodoListQueryResult>(
                    SqliteTodoListScript.GetTodoLists
                    , (todoListResult, todoItemResult) =>
                    {

                        var todoList = todoLists.FirstOrDefault(c => c.Id == Guid.Parse(todoListResult.todo_lista_id));
                        if (todoList == null)
                        {
                            todoList = todoListResult.ToEntity();
                            if (todoItemResult != null)
                            {
                                var todoItem = todoItemResult.ToEntity();
                                todoList.AddTodoItem(todoItem);
                            }
                            todoLists.Add(todoList);
                        }
                        else
                        {
                            if (todoItemResult != null)
                                todoList.AddTodoItem(todoItemResult.ToEntity());
                        }

                        return todoListResult;
                    }
                    , new { customerId }
                    , commandType: CommandType.Text
                    , splitOn: "todo_item_id"
                );

            return todoLists.FirstOrDefault()!;
        }

        public async Task<bool> UpdateAsync(Customer customer, TodoList todoList)
        {
            var result = await context
                .Connection
                .ExecuteAsync(
                    SqliteTodoListScript.UpdateTodoList
                    , new
                    {
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
