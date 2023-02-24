using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.CustomerCommands
{
    public class AuthenticateCustomerByPhoneCommand : ICommand
    {
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool IsValid()
        {
            return true;
        }
    }
}
