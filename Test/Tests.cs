using Xunit;
using LeerlingenProgramma;

namespace Test
{
    public class Tests
    {
        Database DB = new Database();

        [Fact]
        public void TestInlogPagina()
        {
            DB.AddUser("Test","Test");
            DB.LoginControle("Test","Test");
            //Assert.Equal("Test", DB.GetUsername);
        }
    }
}
