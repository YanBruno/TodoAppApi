using Flunt.Notifications;

namespace TodoApp.Core.Src.Entities.Contracts;
public abstract class Entity : Notifiable<Notification>
{
    protected Entity(Guid? id, DateTime? createAt)
    {
        Id = id;
        CreateAt = createAt;

        Id ??= Guid.NewGuid();
        CreateAt ??= DateTime.UtcNow;
    }
    public Guid? Id { get; private set; }
    public DateTime? CreateAt { get; private set; }
}