using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.CustomerCommands;

public class UpdateCustomerCommand : ICommand
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}