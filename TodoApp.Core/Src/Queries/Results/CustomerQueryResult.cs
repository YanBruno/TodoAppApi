using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results.Contracts;
using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Core.Src.Queries.Results;

public class CustomerQueryResult : IQueryResult<Customer>
{
    public string usuario_id { get; set; } = null!;
    public string nome { get; set; } = null!;
    public string sobrenome { get; set; } = null!;
    public string email { get; set; } = null!;
    public string ddd_celular { get; set; } = null!;
    public string numero_celular { get; set; } = null!;
    public string senha { get; set; } = null!;
    public DateTime? create_at  { get; set; } 

    public Customer ToEntity()
    {
        return new Customer(
            Guid.Parse(usuario_id)
            , create_at
            , new Name(nome, sobrenome)
            , new Email(email)
            , new Phone(ddd_celular, numero_celular)
            , new Password(senha)
        );
    }
}
