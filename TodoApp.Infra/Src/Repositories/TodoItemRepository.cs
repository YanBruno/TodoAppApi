using Dapper;
using System.Data;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results;
using TodoApp.Core.Src.Repositories;
using TodoApp.Infra.Src.DataContext.Contracts;
using TodoApp.Infra.Src.Scripts.SqliteScripts;

namespace TodoApp.Infra.Src.Repositories;

public class TodoItemRepository : DefaultConnection, ITodoItemRepository
{
    public Task<bool> ChangeTodoList(Customer customer, TodoList todoList, TodoList newTodoList, TodoItem todoItemId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(Customer customer, TodoList todoList, TodoItem todoItem)
    {
        var result = await context
            .Connection
            .ExecuteAsync(
                SqliteTodoItemScript.InsertTodoItem
                , new {
                    todoItem.Id
                    , todoListId = todoList.Id
                    , customerId = customer.Id
                    , Title = todoItem.Title.Value
                    , Note = todoItem.Note.Value
                    , todoItem.Done
                    , todoItem.CreateAt
                }
                , commandType: CommandType.Text
            );

        if (result > 0) return true;

        return false;
    }

    public async Task<bool> DeleteAsync(Customer customer, TodoList todoList, TodoItem todoItem)
    {
        var result = await context
            .Connection
            .ExecuteAsync(
                SqliteTodoItemScript.DeleteTodoItem
                , new
                {
                    todoItem.Id
                    , todoListId = todoList.Id
                    , customerId = customer.Id
                }
                , commandType: CommandType.Text
            );

        if (result > 0) return true;

        return false;
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync(Guid customerId, Guid todoListId)
    {
        var todos = new List<TodoItem>();
        var result = await context
            .Connection
            .QueryAsync<TodoItemQueryResult>(
                SqliteTodoItemScript.GetTodoItems
                , new {
                    todoListId
                    , customerId
                }
                , commandType: CommandType.Text
            );

        result.ToList().ForEach(
            todo => {
                todos.Add(todo.ToEntity());
            }    
        );

        return todos;
    }

    public async Task<TodoItem> GetByIdAsync(Guid customerId, Guid todoListId, Guid todoItemId)
    {
        var result = await context
            .Connection
            .QueryFirstOrDefaultAsync<TodoItemQueryResult>(
                SqliteTodoItemScript.GetTodoItemById
                , new {
                    todoItemId
                    , todoListId
                    , customerId
                }
                , commandType: CommandType.Text
            );

        if (result != null)
            return result.ToEntity();

        return null!;
    }

    public async Task<bool> UpdateAsync(Customer customer, TodoList todoList, TodoItem todoItem)
    {
        var result = await context
            .Connection
            .ExecuteAsync(
                SqliteTodoItemScript.UpdateTodoItem
                , new
                {
                    Title = todoItem.Title.Value
                    , Note = todoItem.Note.Value
                    , todoItem.Done
                    , todoItem.Id
                    , todoListId = todoList.Id
                    , customerId = customer.Id
                }
                , commandType: CommandType.Text
            );;

        if (result > 0) return true;

        return false;
    }
}
