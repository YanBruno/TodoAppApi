using System.Collections.Generic;

namespace TodoApp.Infra.Src.Scripts.SqliteScripts;

public static class SqliteGenericScripts
{
    public readonly static string CheckEmail = """
        select iif(count(1) = 0, 0, 1)
        from tb_usuario
        where email = @email
    """;
    public readonly static string CheckPhone = """
        select iif(count(1) = 0, 0, 1)
        from tb_usuario
        where 1=1 
            and ddd_celular = @phoneCodeArea
            and numero_celular = @phoneNumber
    """;

    public readonly static string InsertCustomer = """
    insert into tb_usuario
    select
        @Id
        , @FirstName
        , @LastName
        , @Address
        , @CodeArea
        , @Number
        , @Value
        , @CreateAt
    """;
    public readonly static string InsertTodoList = """
    insert into tb_todo_lista
    select
        @Id
        , @customerId
        , @Value
        , @CreateAt
    """;

    public readonly static string GetCustomers = """
        select *
        from tb_usuario t1
        left join tb_todo_lista t2
    	    ON	t2.usuario_id = t1.usuario_id
        left JOIN tb_todo_item t3
    	    ON	t3.todo_lista_id = t2.todo_lista_id
            and t3.usuario_id = t2.usuario_id
    """;
    public readonly static string GetCustomerById = """
        select *
        from tb_usuario t1
        left join tb_todo_lista t2
    	    ON	t2.usuario_id = t1.usuario_id
        left JOIN tb_todo_item t3
    	    ON	t3.todo_lista_id = t2.todo_lista_id
            and t3.usuario_id = t2.usuario_id
        where 1=1
    	    and t1.usuario_id = @param
    """;
    public readonly static string GetCustomerByEmail = """
        select *
        from tb_usuario t1
        left join tb_todo_lista t2
    	    ON	t2.usuario_id = t1.usuario_id
        left JOIN tb_todo_item t3
    	    ON	t3.todo_lista_id = t2.todo_lista_id
            and t3.usuario_id = t2.usuario_id
        where 1=1
    	    and t1.email = @param
    """;

    public readonly static string GetTodoLists = """
    select t2.*
    from tb_usuario t1
    inner join tb_todo_lista t2
    	ON	t2.usuario_id = t1.usuario_id
    where 1=1
        and t1.usuario_id = @customerId
    """;

}