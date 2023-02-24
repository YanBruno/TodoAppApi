using Dapper;
using System.Data;
using TodoApp.Infra.Src.Configs.Contracts;
using TodoApp.Infra.Src.DataContext.Contracts;
using TodoApp.Infra.Src.Scripts.SqliteScripts;
using TodoApp.Share;

namespace TodoApp.Infra.Src.Configs;

public class SqliteBootstrap : DefaultConnection, IDataBaseBootstrap
{
    public void InitialSetup()
    {
        var fullPathDb = Path.Combine(Directory.GetCurrentDirectory(), Settings.SqliteFileName);
        if (File.Exists(fullPathDb)) { File.Delete(fullPathDb); }

        var result = context.Connection.Execute(SqliteBootstrapScript.GenerateScript(), null, commandType: CommandType.Text);

        Console.WriteLine($"Sqlite bootstrap script:\n{SqliteBootstrapScript.GenerateScript()}\n\nLinhas atualziadas: {result}\n\n");
    }
}