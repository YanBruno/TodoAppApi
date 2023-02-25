using TodoApp.Core.Src.Services;

namespace TodoApp.Infra.Src.Services;

public class EmailService : IEmailService
{
    public async Task<bool> SendEmailAsync(string emailTo, string head, string message)
    {
        await Task.Delay(1000);
        return true;
    }
}
