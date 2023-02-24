using TodoApp.Core.Src.Services;

namespace TodoApp.Infra.Src.Services;

public class EmailService : IEmailService
{
    public Task<bool> SendEmailAsync(string emailTo, string head, string message)
    {
        throw new NotImplementedException();
    }
}
