namespace TodoApp.Share;

public static class Settings
{
    public const string SecretToken = "580307dae7cca8f4917ebf8955146e6446f0668a8c30afdc0b5c45a34e3ce2da-TodoApp";
    public const string SqlServerStringConnection = "Server=localhost;Database=louvor_app;Trusted_Connection=True;";
    public const string SqliteFileName = "TodoApp.sqlite";
    public const string SqliteStringConnection = $"Data Source={SqliteFileName}";
}