using System.Text;

namespace TodoApp.Infra.Src.Scripts.SqliteScripts;

public static class SqliteBootstrapScript
{
    private static readonly string createTables = """
        create table tb_usuario (
            usuario_id TEXT PRIMARY KEY
            , nome varchar NOT NULL
            , sobrenome varchar NOT NULL
            , email varchar not NULL
            , ddd_celular varchar not null
            , numero_celular varchar not null
            , senha varchar not null
            , create_at DATE not null
        );
        create table tb_todo_lista (
            todo_lista_id TEXT
            , usuario_id TEXT not null
            , titulo varchar NOT NULL
            , create_at DATE not null
            , CONSTRAINT pk_tb_todo_list PRIMARY KEY (todo_lista_id, usuario_id)
            , FOREIGN KEY(usuario_id) REFERENCES tb_usuario(usuario_id)
        );
        create table tb_todo_item(
            todo_item_id TEXT
            , todo_lista_id text not null
            , usuario_id text not null
            , titulo varchar not NULL
            , nota varchar NULL
            , concluido integer
            , create_at DATE not null
            , CONSTRAINT pk_tb_todo_item PRIMARY KEY (todo_item_id, todo_lista_id, usuario_id)
            , FOREIGN KEY(todo_lista_id, usuario_id) REFERENCES tb_todo_lista(todo_lista_id, usuario_id)
            , FOREIGN KEY(usuario_id) REFERENCES tb_usuario(usuario_id)
        );
    """;
    private static readonly string insertDataOnTables = """
        insert into tb_usuario
        SELECT
            "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "yan"
            , "santos"
            , "yanbrunosilvasantos@gmail.com"
            , "011"
            , "123456789"
            , "Let@12345"
            , "2023-01-01 23:56:34";
        insert into tb_usuario
        SELECT
            "CE076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Joao"
            , "santos"
            , "joao@gmail.com"
            , "011"
            , "123456782"
            , "Let@12345"
            , "2023-01-01 23:56:34";
        insert into tb_todo_lista
        SELECT
            "CEF8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Contas a pagar"
            , "2023-01-01 23:56:34";
        insert into tb_todo_lista
        SELECT
            "ABC8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Tarefas Diarias"
            , "2023-01-01 23:56:34";
        insert into tb_todo_lista
        SELECT
            "AAA8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Tarefas Compartilhadas"
            , "2023-01-01 23:56:34";
        insert into tb_todo_item
        SELECT
            "280BFCDD-4567-4B64-8FE1-A2A7D33514A5"
            , "CEF8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Ituran"
            , "130.00"
            , 1
            , "2023-01-01 23:56:34";
        insert into tb_todo_item
        SELECT
            "140BFCDD-4567-4B64-8FE1-A2A7D33514A5"
            , "CEF8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Nubank"
            , "1000.00"
            , 1
            , "2023-01-01 23:56:34";
        insert into tb_todo_item
        SELECT
            "7D9AF431-101D-4F38-985D-650BAA676C63"
            , "ABC8E5D7-0B02-4BB4-B36B-9D40F210C4C1"
            , "AB076C89-7A54-41E7-8373-7FC98AE7321F"
            , "Sair com cachorro"
            , null
            , 1
            , "2023-01-01 23:56:34";
    """;

    public static string GenerateScript() 
        => BuildScript(
                createTables
                //, insertDataOnTables
            );

    private static string BuildScript(params string[] scripts) 
    {
        var script = new StringBuilder();
        foreach (var item in scripts)
        {
            script.AppendLine(item);
        }
        return $"{script}";
    }

}
