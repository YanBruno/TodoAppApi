using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.TodoItemCommands;
using TodoApp.Core.Src.Commands.Out;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers.Contracts;
using TodoApp.Core.Src.Repositories;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Handlers;

public class TodoItemHandler
    : IHandler<CreateNewTodoItemCommand>
    , IHandler<UpdateTodoItemCommand>
    , IHandler<DeleteTodoItemCommand>
    , IHandler<ChangeTodoItemFromTodoListCommand>
    , IHandler<UpdateTodoItemDoneCommand>
{
    private readonly ICustomerRepository customerRepository;
    private readonly ITodoItemRepository todoItemRepository;

    public TodoItemHandler(ICustomerRepository customerRepository, ITodoItemRepository todoItemRepository)
    {
        this.customerRepository = customerRepository;
        this.todoItemRepository = todoItemRepository;
    }

    public async Task<ICommandResult> HandleAsync(CreateNewTodoItemCommand command)
    {
        if (!command.IsValid()) return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync(command.CustomerId);
        if (customer is null) return new GenericCommandResult("Usuário inválido", false, null);

        var todoList = customer.Lists.FirstOrDefault(list => list.Id == command.TodoListId);
        if (todoList is null) return new GenericCommandResult("Lista inválida", false, null);

        var title = new Title(command.Title);
        var note = new Note(command.Note);
        var todoItem = new TodoItem(null, null, title, note, false);

        if (!todoItem.IsValid) return new GenericCommandResult("Algo errado aconteceu", false, todoItem.Notifications);

        if (!await todoItemRepository.CreateAsync(customer, todoList, todoItem))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Todo criado com sucesso", true, todoItem);
    }

    public async Task<ICommandResult> HandleAsync(UpdateTodoItemCommand command)
    {
        if (!command.IsValid()) return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync((Guid)command.CustomerId!);
        if (customer is null) return new GenericCommandResult("Usuário inválido", false, null);

        var todoList = customer.Lists.FirstOrDefault(list => list.Id == command.TodoListId);
        if (todoList is null) return new GenericCommandResult("Lista inválida", false, null);

        var todoItem = todoList.Todos.FirstOrDefault(todo => todo.Id == command.TodoItemId);
        if (todoItem is null) return new GenericCommandResult("Todo inválido", false, null);

        var newTitle = new Title(command.Title);
        var newNote = new Note(command.Note);

        todoItem.UpdateTitle(newTitle);
        todoItem.UpdateNote(newNote);

        if (!todoItem.IsValid) return new GenericCommandResult("Algo errado aconteceu", false, todoItem.Notifications);

        if (!await todoItemRepository.UpdateAsync(customer, todoList, todoItem))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Todo atualziado com sucesso", true, todoItem);
    }

    public async Task<ICommandResult> HandleAsync(DeleteTodoItemCommand command)
    {
        if (!command.IsValid()) return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync((Guid)command.CustomerId!);
        if (customer is null) return new GenericCommandResult("Usuário inválido", false, null);

        var todoList = customer.Lists.FirstOrDefault(list => list.Id == command.TodoListId);
        if (todoList is null) return new GenericCommandResult("Lista inválida", false, null);

        var todoItem = todoList.Todos.FirstOrDefault(todo => todo.Id == command.TodoItemId);
        if (todoItem is null) return new GenericCommandResult("Todo inválido", false, null);

        if (!await todoItemRepository.DeleteAsync(customer, todoList, todoItem))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Todo deletado com sucesso", true, null);

    }

    public async Task<ICommandResult> HandleAsync(ChangeTodoItemFromTodoListCommand command)
    {
        if (!command.IsValid()) return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync((Guid)command.CustomerId!);
        if (customer is null) return new GenericCommandResult("Usuário inválido", false, null);

        var todoList = customer.Lists.FirstOrDefault(list => list.Id == command.TodoListId);
        if (todoList is null) return new GenericCommandResult("Lista inválida", false, null);

        var todoItem = todoList.Todos.FirstOrDefault(todo => todo.Id == command.TodoItemId);
        if (todoItem is null) return new GenericCommandResult("Todo inválido", false, null);

        var newTodoList = customer.Lists.FirstOrDefault(list => list.Id == command.NewTodoListId);
        if (newTodoList is null) return new GenericCommandResult("Nova Lista inválida", false, null);

        todoList.DeleteTodoItem(todoItem);
        newTodoList.AddTodoItem(todoItem);

        if (!todoItem.IsValid) return new GenericCommandResult("Algo errado aconteceu", false, todoItem.Notifications);

        if (!await todoItemRepository.ChangeTodoList(customer, todoList, newTodoList, todoItem))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Todo atualziado com sucesso", true, todoItem);
    }

    public async Task<ICommandResult> HandleAsync(UpdateTodoItemDoneCommand command)
    {
        if (!command.IsValid()) return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync((Guid)command.CustomerId!);
        if (customer is null) return new GenericCommandResult("Usuário inválido", false, null);

        var todoList = customer.Lists.FirstOrDefault(list => list.Id == command.TodoListId);
        if (todoList is null) return new GenericCommandResult("Lista inválida", false, null);

        var todoItem = todoList.Todos.FirstOrDefault(todo => todo.Id == command.TodoItemId);
        if (todoItem is null) return new GenericCommandResult("Todo inválido", false, null);

        todoItem.UpdateDone();

        var result = await todoItemRepository.UpdateAsync(customer, todoList, todoItem);

        if (!result) return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Todo deletado com sucesso", true, todoItem);
    }
}