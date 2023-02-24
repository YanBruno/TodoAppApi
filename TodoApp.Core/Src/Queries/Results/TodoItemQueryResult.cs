using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Queries.Results;

public class TodoItemQueryResult : IQueryResult<TodoItem>
{
    public string todo_item_id { get; set; } = null!;
    public string todo_lista_id { get; set; } = null!;
    public string usuario_id { get; set; } = null!; 
    public string titulo { get; set; } = null!;
    public string nota { get; set; } = null!;
    public bool concluido { get; set; }
    public DateTime create_at { get; set; }

    public TodoItem ToEntity()
    {
        return new TodoItem(
            Guid.Parse(todo_item_id)
            , create_at
            , new Title(titulo)
            , new Note(nota)
            , concluido
        );
    }
}