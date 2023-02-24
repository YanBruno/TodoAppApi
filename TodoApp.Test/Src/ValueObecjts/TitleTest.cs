using TodoApp.Core.Src.ValueObjects;

namespace TodoApp.Test.Src.ValueObecjts;

[TestClass]
public class TitleTest
{
    [TestMethod]
    public void DeveRtornarIsValidTrueDadoTitleValido()
    {
        var title = new Title("Tarefa 01");
        Assert.IsTrue(title.IsValid);
    }

    [TestMethod]
    public void DeveRtornarIsValidFalseDadoTitleInvalido()
    {
        var title = new Title("Ta");
        Assert.IsFalse(title.IsValid);
    }
}
