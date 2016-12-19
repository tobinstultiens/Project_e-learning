using Xunit;

namespace Test
{
    public class Tests : BaseTestFixture
    {
        [Theory]
        [InlineData("TestLeerling", "TestLeerling", 1, 1)]
        [InlineData("TestLeraar", "TestLeraar", 2, 1)]
        public void Inloggen(string username, string password, int Rol, int niveau)
        {
            DB.AddUser(username, password, Rol, niveau);
            Assert.True(DB.LoginControle(username, password));
        }
        
    }

    public class AlgemeneGegevens
    {
        public string User { get; set; }
        public string Klas { get; set; }
        public int RolID { get; set; }
    }
}
