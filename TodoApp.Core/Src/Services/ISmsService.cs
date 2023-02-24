namespace TodoApp.Core.Src.Services
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string phoneTo, string message);
    }
}
