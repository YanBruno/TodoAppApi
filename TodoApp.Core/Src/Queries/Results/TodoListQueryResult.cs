using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Queries.Results;

public class TodoListQueryResult : IQueryResult<TodoList>
{
    public string todo_lista_id { get; set; } = null!;
    public string usuario_id { get; set; } = null!;
    public string titulo { get; set; } = null!;
    public DateTime? create_at { get; set; }

    public TodoList ToEntity()
    {
        return new TodoList(
            Guid.Parse(todo_lista_id)
            , create_at
            , new Title(titulo)
        );
    }
}
