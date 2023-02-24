namespace TodoApp.Test.Src.Entities.Contracts;

[TestClass]
public class EntityTest
{
    [TestMethod]
    public void DeveRetornarGuidEspecificoDadoGuidInseridoNoConstrutor()
    {
        var guid = Guid.Parse("523270CB-F210-4DB4-8138-BEE3CBFE9FB4");
        var entity = new EntityToTest(guid, null);

        Assert.AreEqual(guid.ToString(), entity.Id.ToString());
    }

    public void DeveRetornarUmNovoGuidDadoNuloNoConstrutor()
    {
        var entity = new EntityToTest(null, null);
        Assert.IsNotNull(entity.Id);
    }
}
