using MySql.Data.MySqlClient;
using System.Data;
using Data;
using System.Data.SqlClient;


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
                string query = "SELECT Name, Category, Recipe, PortionWeight FROM Dish";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetAllProducts()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT Name, Calories, PricePerUnit, UnitOfMeasure FROM product"; // Замените "Products" на название вашей таблицы продуктов
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

        public void UpdateDish(int dishId, string name, string category, string recipe, decimal portionWeight)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Dish
                    SET Name = @Name,
                        Category = @Category,
                        Recipe = @Recipe,
                        PortionWeight = @PortionWeight
                    WHERE DishID = @DishID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Передача параметров для предотвращения SQL-инъекций
                    cmd.Parameters.AddWithValue("@DishID", dishId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Recipe", recipe);
                    cmd.Parameters.AddWithValue("@PortionWeight", portionWeight);

                    cmd.ExecuteNonQuery(); // Выполняем SQL-запрос
                }
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