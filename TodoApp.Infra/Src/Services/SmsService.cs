using TodoApp.Core.Src.Services;

namespace TodoApp.Infra.Src.Services;

public class SmsService : ISmsService
{
    public Task<bool> SendSmsAsync(string phoneTo, string message)
    {
        throw new NotImplementedException();
    }
}
