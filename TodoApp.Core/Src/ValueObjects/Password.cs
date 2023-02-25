using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects
{
    public class Password : ValueObject
    {
        private string Value { get; set; } = null!;

        public Password(string value)
        {
            this.Value = value;
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