using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Test.Src.ValueObecjts;

[TestClass]
public class NameTest
{
    [TestMethod]
    public void DeveRetornarIsValidTrueDadoNomeValido()
    {
        var name = new Name("Yan", "Santos");
        Assert.IsTrue(name.IsValid);
    }

    [TestMethod]
    public void DeveRetornarIsValidFalseDadoNomeInvalido()
    {
        var name = new Name("Ya", "Santos");
        Assert.IsFalse(name.IsValid);
    }
}
