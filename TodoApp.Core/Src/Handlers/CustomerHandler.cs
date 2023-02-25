
using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.CustomerCommands;
using TodoApp.Core.Src.Commands.Out;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers.Contracts;
using TodoApp.Core.Src.Repositories;
using TodoApp.Core.Src.Services;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Handlers;

public class CustomerHandler
    : IHandler<CreateCustomerCommand>
    , IHandler<UpdateCustomerCommand>
    , IHandler<AuthenticateCustomerByEmailCommand>
    , IHandler<AuthenticateCustomerByPhoneCommand>
{
    private readonly ICustomerRepository customerRepository;
    private readonly ISmsService smsService;
    private readonly IEmailService emailService;
    private readonly ITokenService tokenService;

    public CustomerHandler(ICustomerRepository customerRepository, ISmsService smsService, IEmailService emailService, ITokenService tokenService)
    {
        this.customerRepository = customerRepository;
        this.smsService = smsService;
        this.emailService = emailService;
        this.tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(CreateCustomerCommand command)
    {
        if (!command.IsValid())
            return new GenericCommandResult("Comando inválido", false, null);

        var taskcheckEmail = customerRepository.CheckByEmail(command.EmailAddress);
        var taskCheckPhone = customerRepository.CheckByPhone(command.PhoneCodeArea, command.PhoneNumber);

        await Task.WhenAll(taskcheckEmail, taskCheckPhone);

        if (taskcheckEmail.Result) return new GenericCommandResult("E-mail inválido", false, null);
        if (taskCheckPhone.Result) return new GenericCommandResult("Telefone inválido", false, null);


        var name = new Name(command.FirstName, command.LastName);
        var email = new Email(command.EmailAddress);
        var password = new Password(command.Password);
        var phone = new Phone(command.PhoneCodeArea, command.PhoneNumber);

        var customer = new Customer(null, null, name, email, phone, password);

        if (!customer.IsValid)
            return new GenericCommandResult("Algo deu errado", false, customer.Notifications);

        if (!await customerRepository.CreateAsync(customer))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        var emailTask = emailService.SendEmailAsync(customer.Email.Address, "Welcome to TodoApp", "Welcom to TodoApp");
        var smsTask = smsService.SendSmsAsync($"{customer.Phone}", "Welcome to TodoApp");

        var token = tokenService.GetToken(customer);

        await Task.WhenAll(emailTask, smsTask);
        return new GenericCommandResult("Usuário criado com sucesso", true, new { customer, token });
    }

    public async Task<ICommandResult> HandleAsync(UpdateCustomerCommand command)
    {
        if (!command.IsValid())
            return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByIdAsync(command.CustomerId);
        var name = new Name(command.FirstName, command.LastName);

        customer.UpdateName(name);

        if (!customer.IsValid)
            return new GenericCommandResult("Algo deu errado", false, customer.Notifications);

        if (!await customerRepository.UpdateAsync(customer))
            return new GenericCommandResult("Erro ao persistir dados", false, null);

        return new GenericCommandResult("Usuário atualizado", true, customer);
    }

    public async Task<ICommandResult> HandleAsync(AuthenticateCustomerByPhoneCommand command)
    {
        if (!command.IsValid())
            return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByPhoneAsync(command.PhoneNumber);

        if (customer is null)
            return new GenericCommandResult("Usuário ou senha incorreto", false, null);

        if (customer.Password.GetPassword() != command.Password)
            return new GenericCommandResult("Usuário ou senha incorreto", false, null);

        var token = tokenService.GetToken(customer);
        return new GenericCommandResult("Login sucesso", true, new { customer, token });
    }

    public async Task<ICommandResult> HandleAsync(AuthenticateCustomerByEmailCommand command)
    {
        if (!command.IsValid())
            return new GenericCommandResult("Comando inválido", false, null);

        var customer = await customerRepository.GetByEmailAsync(command.Email);

        if (customer is null)
            return new GenericCommandResult("Usuário ou senha incorreto", false, null);

        if (customer.Password.GetPassword() != command.Password)
            return new GenericCommandResult("Usuário ou senha incorreto", false, null);

        var token = tokenService.GetToken(customer);
        return new GenericCommandResult("Login sucesso", true, new { customer, token });

    }
}