using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects
{
    public class Note : ValueObject
    {
        public string Value { get; private set; } = null!;

        public Note(string value)
        {
            Value = value;

            //AddNotifications(new CreateNoteContract(this));
        }

        public Note()
        {
        }
    }
}
