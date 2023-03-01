namespace TodoApp.Infra.Src.Scripts.SqliteScripts;

public static class SqliteTodoItemScript
{
    public static readonly string InsertTodoItem = """
    insert into tb_todo_item
    select
        @Id
        , @todoListId
        , @customerId
        , @Title
        , @Note
        , @Done
        , @CreateAt
    """;

    public static readonly string GetTodoItems = """
    Select t3.*
    from tb_todo_item t3
    where 1=1
        and t3.todo_lista_id = @todoListId
        and t3.usuario_id = @customerId
    """;

    public static readonly string GetTodoItemById = """
    Select t3.*
    from tb_todo_item t3
    where 1=1
        and t3.todo_item_id = @todoItemId
        and t3.todo_lista_id = @todoListId
        and t3.usuario_id = @customerId;
    """;

    public static readonly string DeleteTodoItem = """
    delete from tb_todo_item
    where 1=1
        and todo_item_id = @Id
        and todo_lista_id = @todoListId
        and usuario_id = @customerId;

    """;

    public static readonly string UpdateTodoItem = """
    update tb_todo_item set
    	titulo = @Title
        , nota = @Note
        , concluido = @Done
    where 1=1
        and todo_item_id = @Id
        and todo_lista_id = @todoListId
        and usuario_id = @customerId;
    """;

}
