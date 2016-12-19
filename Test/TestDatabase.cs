using MySql.Data.MySqlClient;
using System.Configuration;


namespace Test
{
    public class TestDatabase
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
        public void AddUser(string Username, string Password, int RolID, int niveau)
        {
            GetDBConnection().Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO user(username, wachtwoord, rol_idrol1, niveau_idniveau) VALUES(@username, @wachtwoord, @RolID, @niveau)";
            comm.Parameters.AddWithValue("@username", Username);
            comm.Parameters.AddWithValue("@wachtwoord", Password);
            comm.Parameters.AddWithValue("@RolID", RolID);
            comm.Parameters.AddWithValue("@niveau", niveau);
            comm.ExecuteNonQuery();
            GetDBConnection().Close();
        }

        public AlgemeneGegevens ReadRolID(string username)
        {
            var result = new AlgemeneGegevens();
            GetDBConnection().Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "select * from `user` where `username` = @username";
            comm.Parameters.AddWithValue("@username", username);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                result.RolID = reader.GetInt32("rol_idrol1");
            }
            GetDBConnection().Close();
            return result;
        }

        public void Purge()
        {
            GetDBConnection().Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM user";
            cmd.ExecuteNonQuery();
            GetDBConnection().Close();
        }
    }
}
