using TodoApp.Core.Src.Services;

namespace TodoApp.Infra.Src.Services;

public class SmsService : ISmsService
{
    public async Task<bool> SendSmsAsync(string phoneTo, string message)
    {
        await Task.Delay(1000);
        return true;
    }
}
