using TodoApp.Core.Src.Entities.Contracts;

namespace TodoApp.Core.Src.Queries.Results.Contracts;

public interface IQueryResult<T> where T : Entity
{
    T ToEntity();
}
