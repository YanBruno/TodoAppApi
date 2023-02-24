using Microsoft.Data.Sqlite;
using System.Data;
using TodoApp.Share;

namespace TodoApp.Infra.Src.DataContext;

public class TodoAppContext : IDisposable
{
    public TodoAppContext()
    {
        Connection = new (Settings.SqliteStringConnection);
    }

    public SqliteConnection Connection { get; private set; }

    public void Dispose()
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
    }
}
