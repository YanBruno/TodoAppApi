namespace TodoApp.Infra.Src.DataContext.Contracts;

public abstract class DefaultConnection
{
    protected readonly TodoAppContext context;

    protected DefaultConnection()
    {
        context = new TodoAppContext();
    }
}
