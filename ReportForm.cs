using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Data;


namespace cooking
{
    public partial class ReportForm : Form
    {
        private Data.Database db = new Data.Database();

        public ReportForm()
        {
            InitializeComponent();
        }
        
        private void btnDishCount_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) AS TotalDishes FROM Dish";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                lblReportResult.Text = $"Общее количество блюд: {result}";
            }
        }
    }
}
