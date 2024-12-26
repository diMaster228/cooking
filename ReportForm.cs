using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Data;
using System.Data;
using System.Drawing;
using System.Linq;


namespace cooking
{
    public partial class ReportForm : BaseMaterialForm
    {
        private Data.Database db = new Data.Database();
        private MainForm mainForm; // Ссылка на главную форму
        private DishForm dishForm; // Ссылка на форму блюд
        private ProductForm productForm;

        public ReportForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnToMainForm_Click(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                MessageBox.Show("Ошибка: ссылка на MainForm отсутствует.");
                return;
            }

            this.Hide();
            mainForm.Show();
        }

        private void btnToDishForm_Click(object sender, EventArgs e)
        {
            if (dishForm == null) dishForm = new DishForm(mainForm);
            this.Hide();
            dishForm.Show();
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

        private void btnToProductForm_Click(object sender, EventArgs e)
        {
            if (productForm == null)
                productForm = new ProductForm(mainForm, this); // Передаем обе ссылки

            this.Hide(); // Скрываем текущую форму
            productForm.Show(); // Показываем форму продуктов
        }

        private void query1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // SQL-запрос для получения данных
                    string query = @"SELECT d.Name 
                             FROM Dish AS d
                             JOIN DishComposition AS dc ON dc.DishID = d.DishID
                             WHERE dc.PreparationMethod = 'пассеровка'";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    // Создаём DataGridView
                    DataGridView dgvResults = new DataGridView
                    {
                        DataSource = table,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        Dock = DockStyle.Bottom, // Размещаем внизу формы
                        Height = 200 // Высота таблицы
                    };

                    // Настраиваем внешний вид таблицы
                    dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                    dgvResults.DefaultCellStyle.Font = new Font("Arial", 10);
                    dgvResults.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    dgvResults.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

                    // Удаляем существующий DataGridView (если есть)
                    foreach (Control control in this.Controls)
                    {
                        if (control is DataGridView existingGrid)
                        {
                            this.Controls.Remove(existingGrid);
                            existingGrid.Dispose();
                        }
                    }

                    // Добавляем DataGridView на форму
                    this.Controls.Add(dgvResults);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }




        private void query2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // SQL-запрос для расчёта калорийности порций
                    string query = @"
                SELECT d.Name AS DishName,
                       SUM(dc.Quantity * p.Calories) / d.PortionWeight AS CaloriesPerPortion
                FROM Dish AS d
                JOIN DishComposition AS dc ON dc.DishID = d.DishID
                JOIN Product AS p ON p.ProductID = dc.ProductID
                GROUP BY d.DishID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    // Создаём DataGridView
                    DataGridView dgvResults = new DataGridView
                    {
                        DataSource = table,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        Dock = DockStyle.Bottom, // Размещаем внизу формы
                        Height = 200 // Высота таблицы
                    };

                    // Настраиваем внешний вид таблицы
                    dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                    dgvResults.DefaultCellStyle.Font = new Font("Arial", 10);
                    dgvResults.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    dgvResults.DefaultCellStyle.SelectionBackColor = Color.LightGreen;

                    // Удаляем существующий DataGridView (если есть)
                    foreach (Control control in this.Controls)
                    {
                        if (control is DataGridView existingGrid)
                        {
                            this.Controls.Remove(existingGrid);
                            existingGrid.Dispose();
                        }
                    }

                    // Добавляем DataGridView на форму
                    this.Controls.Add(dgvResults);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }


        private void query3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // SQL-запрос для поиска блюда с наибольшим количеством продуктов категории 'Пряность'
                    string query = @"
                SELECT d.Name 
                FROM Dish AS d
                JOIN DishComposition AS dc ON dc.DishID = d.DishID
                JOIN Product AS p ON p.ProductID = dc.ProductID
                JOIN ProductCategory AS pc ON pc.CategoryID = p.CategoryID
                WHERE pc.name = 'Пряность'
                GROUP BY d.DishID
                ORDER BY COUNT(dc.ProductID) DESC
                LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Выполняем запрос и получаем результат
                    object result = cmd.ExecuteScalar();

                    // Проверяем, есть ли результат
                    if (result != null)
                    {
                        string dishName = result.ToString();

                        // Создаём или обновляем Label для отображения результата
                        Label lblResult = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblQuery3Result");

                        if (lblResult == null)
                        {
                            lblResult = new Label
                            {
                                Name = "lblQuery3Result",
                                AutoSize = true,
                                Font = new Font("Arial", 14, FontStyle.Bold),
                                ForeColor = Color.DarkBlue,
                                Location = new Point(10, this.Height - 50) // Располагаем внизу формы
                            };
                            this.Controls.Add(lblResult);
                        }

                        lblResult.Text = $"Блюдо с наибольшим количеством продуктов категории 'Пряность': {dishName}";
                    }
                    else
                    {
                        MessageBox.Show("Не найдено блюд с продуктами категории 'Пряность'.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }


        private void query4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // SQL-запрос для получения списка блюд категории 'первое' и их продуктов
                    string query = @"
                SELECT d.Name AS DishName, p.Name AS ProductName
                FROM Dish AS d
                JOIN DishComposition AS dc ON d.DishID = dc.DishID
                JOIN Product AS p ON dc.ProductID = p.ProductID
                WHERE d.Category = 'первое'
                ORDER BY d.Name, dc.OrderOfAdding";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Выполняем запрос
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Создаём или обновляем DataGridView для отображения результата
                    DataGridView dgvQuery4Result = this.Controls.OfType<DataGridView>().FirstOrDefault(dgv => dgv.Name == "dgvQuery4Result");

                    if (dgvQuery4Result == null)
                    {
                        dgvQuery4Result = new DataGridView
                        {
                            Name = "dgvQuery4Result",
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            Location = new Point(10, this.Height - 300),
                            Size = new Size(this.Width - 40, 200),
                            ReadOnly = true
                        };
                        this.Controls.Add(dgvQuery4Result);
                    }

                    // Привязываем данные к DataGridView
                    dgvQuery4Result.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }

        private void paramQuery_Click(object sender, EventArgs e)
        {
            // Получаем значение из текстового поля (например, для категории блюда)
            string categoryName = categoryTextBox.Text; // categoryTextBox — это TextBox, где пользователь вводит категорию

            // Проверяем, что пользователь ввел значение
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Пожалуйста, введите категорию блюда.");
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Параметрический запрос
                    string query = @"
                SELECT d.Name AS DishName, 
                       p.Name AS ProductName 
                FROM Dish AS d
                JOIN DishComposition AS dc ON d.DishID = dc.DishID
                JOIN Product AS p ON dc.ProductID = p.ProductID
                WHERE d.Category = @CategoryName";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Добавляем параметр с значением, введенным пользователем
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName); // categoryName - значение из TextBox

                        // Выполняем запрос и читаем результат
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);

                            // Отображаем результат в DataGridView
                            DataGridView dgv = new DataGridView
                            {
                                DataSource = table,
                                Dock = DockStyle.Fill
                            };
                            this.Controls.Add(dgv);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения параметрического запроса: {ex.Message}");
                }
            }
        }


        private void crossQuery_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Перекрестный запрос для вычисления общей стоимости продуктов в каждом блюде
                    string minCost = minCostTextBox.Text; // где minCostTextBox - TextBox для ввода минимальной стоимости
                    string query = $@"
                        SELECT d.Name AS DishName, 
                        SUM(dc.Quantity * p.PricePerUnit) AS TotalCost
                        FROM Dish AS d
                        JOIN DishComposition AS dc ON d.DishID = dc.DishID
                        JOIN Product AS p ON dc.ProductID = p.ProductID
                        GROUP BY d.Name
                        HAVING TotalCost > {minCost}";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Выполняем запрос и читаем результат
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);

                            // Отображаем результат в DataGridView
                            DataGridView dgv = new DataGridView
                            {
                                DataSource = table,
                                Dock = DockStyle.Fill
                            };
                            this.Controls.Add(dgv);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения перекрестного запроса: {ex.Message}");
                }
            }
        }


        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
