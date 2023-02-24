namespace TodoApp.Core.Src.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string emailTo, string head, string message);
    }
}
