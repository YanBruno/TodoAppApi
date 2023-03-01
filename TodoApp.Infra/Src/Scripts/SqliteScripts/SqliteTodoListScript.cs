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
    select *
    from tb_todo_lista t1
    left join tb_todo_item t2
        on t1.todo_lista_id = t2.todo_lista_id
        and t1.usuario_id = t2.usuario_id
    where 1=1
        and t1.usuario_id = @customerId
    """;

    public static readonly string GetTodoListById = """
    select *
    from tb_todo_lista t1
    inner join tb_todo_item t2
        on t2.todo_lista_id = t2.todo_lista_id
        and t1.usuario_id = t2.usuario_id
    where 1=1
        and t1.usuario_id = @customerId
        and t1.todo_lista_id = @todoListId
    """;

    public static readonly string DeleteTodoList = """
    delete from tb_todo_item
          where 1=1
          and usuario_id = @customerId
          and todo_lista_id = @todoListId;
    delete from tb_todo_lista
    	where 1=1
          and usuario_id = @customerId
          and todo_lista_id = @todoListId;
    """;

    public static readonly string UpdateTodoList = """
    update tb_todo_lista set
    	titulo = @Value
    where 1=1
        and usuario_id = @customerId
        and todo_lista_id = @todoListId;
    """;
}
