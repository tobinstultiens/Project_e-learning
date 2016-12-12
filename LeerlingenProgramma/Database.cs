using MySql.Data.MySqlClient;
using System.Configuration;


namespace LeerlingenProgramma
{
    public class Database
    {
        static MySqlConnection con = null;
        public static MySqlConnection GetDBConnection()
        {
            if (con == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new MySqlConnection(connectionString);
            }
            return con;
        }
        public bool LoginControle(string sUsername, string sPassword)
        {
            GetDBConnection().Open();
            MySqlCommand check_PostCode = new MySqlCommand("select * from user where username = @username and wachtwoord = @password", con);
            check_PostCode.Parameters.AddWithValue("@username", sUsername);
            check_PostCode.Parameters.AddWithValue("@password", sPassword);
            MySqlDataReader reader = check_PostCode.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count += 1;
            }
            if (count >= 1)
            {
                GetDBConnection().Close();
                return true;
            }
            else
            {
                GetDBConnection().Close();
                return false;
            }
        }
        public void AddUser(string Username, string Password)
        {
            GetDBConnection().Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO user(username, wachtwoord) VALUES(@username, @wachtwoord)";
            comm.Parameters.AddWithValue("@username", Username);
            comm.Parameters.AddWithValue("@wachtwoord", Password);
            comm.ExecuteNonQuery();
            GetDBConnection().Close();
        }
    }
}
