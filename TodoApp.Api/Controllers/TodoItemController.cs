using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.TodoItemCommands;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers;
using TodoApp.Core.Src.Repositories;

namespace TodoApp.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TodoItemController : ControllerBase
{
    private readonly TodoItemHandler todoListHandler;
    private readonly ITodoItemRepository todoListRepository;

    public TodoItemController(TodoItemHandler todoListHandler, ITodoItemRepository todoListRepository)
    {
        this.todoListHandler = todoListHandler;
        this.todoListRepository = todoListRepository;
    }

    [HttpGet("{todoListId:guid}/{id:guid}")]
    [Authorize]
    public Task<TodoItem> Get([FromRoute] Guid todoListId, [FromRoute] Guid id)
    {
        return todoListRepository.GetByIdAsync(Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value), todoListId, id);
    }

    [HttpGet("{todoListId:guid}/all")]
    [Authorize]
    public Task<IEnumerable<TodoItem>> GetAll([FromRoute] Guid todoListId)
    {
        return todoListRepository.GetAllAsync(Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value), todoListId);
    }

    [HttpPost("new")]
    [Authorize]
    public Task<ICommandResult> New([FromBody] CreateNewTodoItemCommand command)
    {
        command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        return todoListHandler.HandleAsync(command);
    }

    [HttpDelete]
    [Authorize]
    public Task<ICommandResult> Delete([FromBody] DeleteTodoItemCommand command)
    {
        command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        return todoListHandler.HandleAsync(command);
    }

    [HttpPut]
    [Authorize]
    public Task<ICommandResult> Update([FromBody] UpdateTodoItemCommand command)
    {
        command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        return todoListHandler.HandleAsync(command);
    }

    [HttpPut("done")]
    [Authorize]
    public Task<ICommandResult> Done([FromBody] MarkTodoItemDone command)
    {
        command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        return todoListHandler.HandleAsync(command);
    }

}
