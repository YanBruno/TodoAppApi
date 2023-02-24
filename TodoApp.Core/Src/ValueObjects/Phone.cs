using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Core.Src.ValueObjects.Contracts;

namespace TodoApp.Core.Src.ValueObjects
{
    public class Phone : ValueObject
    {
        public Phone()
        {
        }

        public Phone(string codeArea, string number)
        {
            CodeArea = codeArea;
            Number = number;

            AddNotifications(
                new Contract<Notification>()
                .AreEquals(CodeArea, 3, "Telefone.DDD")
                .AreEquals(Number, 9, "Telefone.Numero")
            //.IsPhoneNumber(ToString(), "Telefone.ToString")
            );
        }

        public string CodeArea { get; private set; } = null!;
        public string Number { get; private set; } = null!;

        public override string ToString()
        {
            return $"+55{CodeArea}{Number}";
        }
    }
}
