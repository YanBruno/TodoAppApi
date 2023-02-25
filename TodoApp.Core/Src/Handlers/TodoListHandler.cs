using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.TodoListCommands;
using TodoApp.Core.Src.Commands.Out;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers.Contracts;
using TodoApp.Core.Src.Repositories;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Handlers;

public class TodoListHandler
    : IHandler<CreateNewTodoListCommand>
    , IHandler<DeleteTodoListCommand>
    , IHandler<UpdateTodoListCommand>
{
    private readonly ITodoListRepository todoListRepository;
    private readonly ICustomerRepository customerRepository;

    public TodoListHandler(ITodoListRepository todoListRepository, ICustomerRepository customerRepository)
    {
        this.todoListRepository = todoListRepository;
        this.customerRepository = customerRepository;
    }

    public async Task<ICommandResult> HandleAsync(CreateNewTodoListCommand command)
    {
        if (!command.IsValid())
            return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync((Guid)command.CustomerId!);
        if(customer == null)
            return new GenericCommandResult("Usuário inválido", false, null);

        var title = new Title(command.Title!);
        var todoList = new TodoList(Guid.NewGuid(), DateTime.UtcNow, title);

        if(!todoList.IsValid)
            return new GenericCommandResult("Ops, algo errado aconteceu", false, todoList.Notifications);

        customer.AddTodoList(todoList);

        var result = await todoListRepository.CreateAsync(customer, todoList);
        if(!result)
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Lista criada com sucesso", true, todoList);
    }

    public Task<ICommandResult> HandleAsync(UpdateTodoListCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> HandleAsync(DeleteTodoListCommand command)
    {
        throw new NotImplementedException();
    }
}