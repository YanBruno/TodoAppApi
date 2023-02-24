using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Test.Src.ValueObecjts;

[TestClass]
public class EmailTest
{
    [TestMethod]
    public void DeveRetornarIsValidTrueDadoEmailValido()
    {
        var email = new Email("yan@gmail.com");
        Assert.IsTrue(email.IsValid);
    }
    [TestMethod]
    public void DeveRetornarIsValidFalseDadoEmailInalido()
    {
        var email = new Email("yangmail.com");
        Assert.IsFalse(email.IsValid);
    }
}