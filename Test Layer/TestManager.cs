using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Test_Layer;

[TestFixture]
public class TestManager
{
    internal static GameCompanyDbContext dbContext;

    static TestManager()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseInMemoryDatabase("inMemoryDb");
        dbContext = new GameCompanyDbContext(builder.Options);
    }

    [OneTimeTearDown]
    public void Dispose()
    {
        dbContext.Dispose();
    }
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
