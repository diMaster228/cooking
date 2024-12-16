using MySql.Data.MySqlClient;
namespace Data
{


    public class Database
    {
        private string connectionString = "server=localhost;database=cooking;uid=root;pwd=123456;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}