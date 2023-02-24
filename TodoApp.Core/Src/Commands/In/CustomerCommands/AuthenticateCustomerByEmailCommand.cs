using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.CustomerCommands
{
    public class AuthenticateCustomerByEmailCommand : ICommand
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool IsValid()
        {
            return true;
        }
    }
}
