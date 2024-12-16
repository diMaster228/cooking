using MySql.Data.MySqlClient;
using System.Data;
using Data;


namespace cooking
{
    public class DishDAL
    {
        private Database db = new Database();

        public DataTable GetAllDishes()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Dish";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void AddDish(string name, string category, string recipe, decimal portionWeight)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Dish (Name, Category, Recipe, PortionWeight) VALUES (@Name, @Category, @Recipe, @PortionWeight)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Recipe", recipe);
                cmd.Parameters.AddWithValue("@PortionWeight", portionWeight);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDish(int dishId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Dish WHERE DishID = @DishID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DishID", dishId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}