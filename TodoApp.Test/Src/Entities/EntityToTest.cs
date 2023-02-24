using TodoApp.Core.Src.Entities.Contracts;

namespace TodoApp.Test.Src.Entities;

public class EntityToTest : Entity
{
    public EntityToTest(Guid? id, DateTime? createAt) : base(id, createAt)
    {
    }
}
