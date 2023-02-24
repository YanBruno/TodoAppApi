using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; private set; } = null!;

        public Password()
        {
        }

        public Password(string value)
        {
            Value = value;
            AddNotifications(new RegexValidationPasswordContract(this));
        }

        public string GetPassword() => Value;

        public void UpdatePassword(Password password)
        {
            Value = password.GetPassword();
            AddNotifications(new RegexValidationPasswordContract(this));
        }
    }
}