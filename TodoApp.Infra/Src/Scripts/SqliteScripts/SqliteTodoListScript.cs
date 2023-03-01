namespace TodoApp.Infra.Src.Scripts.SqliteScripts;

public static class SqliteTodoListScript
{
    public static readonly string InsertTodoList = """
    insert into tb_todo_lista
    select
        @Id
        , @customerId
        , @Value
        , @CreateAt
    """;

    public static readonly string GetTodoLists = """
    select t2.*
    from tb_usuario t1
    inner join tb_todo_lista t2
    	ON	t2.usuario_id = t1.usuario_id
    where 1=1
        and t1.usuario_id = @customerId
    """;

    public static readonly string GetTodoListById = """
    select t2.*
    from tb_usuario t1
    inner join tb_todo_lista t2
    	ON	t2.usuario_id = t1.usuario_id
    where 1=1
        and t1.usuario_id = @customerId
        and t2.todo_lista_id = @todoListId
    """;

    public static readonly string DeleteTodoLists = """
    delete from tb_todo_item
          where 1=1
          and usuario_id = @customerId
          and todo_lista_id = @todoListId;
    delete from tb_todo_lista
    	where 1=1
          and usuario_id = @customerId
          and todo_lista_id = @todoListId;
    """;

    public static readonly string UpdateTodoLists = """
    update tb_todo_lista set
    	titulo = @Value
    where 1=1
        and usuario_id = @customerId
        and todo_lista_id = @todoListId;
    """;
}
