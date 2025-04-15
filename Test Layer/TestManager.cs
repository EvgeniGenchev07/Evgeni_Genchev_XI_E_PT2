using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Test_Layer;

[TestFixture]
public class TestManager
{
    internal static LibraryDbContext dbContext;

    static TestManager()
    {
        dbContext = new LibraryDbContext(options=>options.UseInMemoryDatabase("inMemoryDb"));
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
