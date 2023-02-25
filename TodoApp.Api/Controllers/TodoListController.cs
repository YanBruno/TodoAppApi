using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.TodoListCommands;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers;
using TodoApp.Core.Src.Repositories;

namespace TodoApp.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private readonly TodoListHandler todoListHandler;
    private readonly ITodoListRepository todoListRepository;

    public TodoListController(TodoListHandler todoListHandler, ITodoListRepository todoListRepository)
    {
        this.todoListHandler = todoListHandler;
        this.todoListRepository = todoListRepository;
    }

    [HttpGet("all")]
    [Authorize]
    public Task<IEnumerable<TodoList>> GetAll()
    {
        return todoListRepository.GetAllAsync(Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value));
    }

    [HttpPost("new")]
    [Authorize]
    public Task<ICommandResult> New(CreateNewTodoListCommand command)
    { 
        command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        return todoListHandler.HandleAsync(command);
    }
}
