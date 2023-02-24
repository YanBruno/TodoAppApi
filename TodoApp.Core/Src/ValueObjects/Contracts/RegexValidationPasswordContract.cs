using Flunt.Notifications;
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace TodoApp.Core.Src.ValueObjects.Contracts
{
    public class RegexValidationPasswordContract : Contract<Notification>
    {
        public RegexValidationPasswordContract(Password password)
        {
            Regex minCaracteres = new("^.{8,}$");
            Regex upperCase = new("^(?=.*?[A-Z])");
            Regex lowerCase = new("^(?=.*?[a-z])");
            Regex numeric = new("^(?=.*?[0-9])");
            Regex special = new("^(?=.*?[#?!@$%^&*-])");

            if (!minCaracteres.IsMatch(password.GetPassword())) AddNotification("Password.Value", "minCaracteres");
            if (!upperCase.IsMatch(password.GetPassword())) AddNotification("Password.Value", "upperCase");
            if (!lowerCase.IsMatch(password.GetPassword())) AddNotification("Password.Value", "lowerCase");
            if (!numeric.IsMatch(password.GetPassword())) AddNotification("Password.Value", "numeric");
            if (!special.IsMatch(password.GetPassword())) AddNotification("Password.Value", "special");
        }
    }
}
