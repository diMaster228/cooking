using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Data;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;


namespace cooking
{
    public partial class ReportForm : BaseFormWithMaterial
    {
        private Data.Database db = new Data.Database();
        private MainForm mainForm; // Ссылка на главную форму
        private DishForm dishForm; // Ссылка на форму блюд
        private ProductForm productForm;

        public ReportForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mainForm.ThemeChanged += UpdateTheme;
            UpdateTheme(mainForm.IsDarkModeChecked());

            minCostTextBox.Text = "Введите минимальную стоимость...";
            minCostTextBox.Enter += minCostTextBox_Enter;
            minCostTextBox.Leave += minCostTextBox_Leave;

            categoryTextBox.Text = "Введите категорию...";
            categoryTextBox.Enter += categoryTextBox_Enter;
            categoryTextBox.Leave += categoryTextBox_Leave;

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

        public override void UpdateTheme(bool isDarkMode)
        {
            base.UpdateTheme(isDarkMode); // Вызов метода из BaseForm для применения темы

            // Обновление фона формы
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            // Обновление фона и цвета текста для всех элементов на форме
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : SystemColors.Control;
                    button.ForeColor = isDarkMode ? Color.White : SystemColors.ControlText;
                    button.FlatStyle = FlatStyle.Flat;  // Сделаем кнопки с плоским стилем
                    button.FlatAppearance.BorderColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.ControlDark;
                }
                else if (control is Label label)
                {
                    label.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    textBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                    textBox.BorderStyle = BorderStyle.FixedSingle;  // Добавляем рамку
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    comboBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                    checkBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.ForeColor = isDarkMode ? Color.White : Color.Black;
                    radioButton.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : Color.White;
                    dgv.ForeColor = isDarkMode ? Color.White : Color.Black;
                    dgv.GridColor = isDarkMode ? Color.Gray : Color.Silver;
                    dgv.DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    dgv.DefaultCellStyle.ForeColor = isDarkMode ? Color.White : Color.Black;
                    dgv.DefaultCellStyle.SelectionBackColor = isDarkMode ? Color.FromArgb(0, 122, 204) : Color.LightBlue;
                    dgv.DefaultCellStyle.SelectionForeColor = isDarkMode ? Color.White : Color.Black;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                // Добавьте другие элементы управления по мере необходимости
            }
        }

        private void btnToDishForm_Click(object sender, EventArgs e)
        {
            if (dishForm == null) dishForm = new DishForm(mainForm);
            this.Hide();
            dishForm.Show();
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

                    string query = @"SELECT d.Name 
                             FROM Dish AS d
                             JOIN DishComposition AS dc ON dc.DishID = d.DishID
                             WHERE dc.PreparationMethod = 'пассеровка'";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    // Открываем результаты в новом окне
                    QueryResultsForm resultsForm = new QueryResultsForm(table, mainForm);
                    resultsForm.Show(); // Можно использовать ShowDialog() для модального окна
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }





        private void query2_Click(object sender, EventArgs e)
        {
            // Удаляем все существующие DataGridView
            foreach (Control control in this.Controls.OfType<DataGridView>().ToList())
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

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

                     

                    // Удаляем существующий DataGridView (если есть)
                    foreach (Control control in this.Controls)
                    {
                        if (control is DataGridView existingGrid)
                        {
                            this.Controls.Remove(existingGrid);
                            existingGrid.Dispose();
                        }
                    }

                    // Открываем результаты в новом окне
                    QueryResultsForm resultsForm = new QueryResultsForm(table, mainForm);
                    resultsForm.Show(); // Можно использовать ShowDialog() для модального окна
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
            SELECT d.Name AS DishName, COUNT(dc.ProductID) AS ProductCount
            FROM Dish AS d
            JOIN DishComposition AS dc ON dc.DishID = d.DishID
            JOIN Product AS p ON p.ProductID = dc.ProductID
            JOIN ProductCategory AS pc ON pc.CategoryID = p.CategoryID
            WHERE pc.name = 'Пряность'
            GROUP BY d.DishID
            ORDER BY ProductCount DESC
            LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Выполняем запрос и получаем результат
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Создаем DataTable для хранения результатов
                            DataTable resultsTable = new DataTable();
                            resultsTable.Columns.Add("Блюдо", typeof(string));
                            resultsTable.Columns.Add("Количество продуктов категории 'пряность'", typeof(int));

                            // Читаем данные из результата и добавляем в таблицу
                            while (reader.Read())
                            {
                                resultsTable.Rows.Add(reader["DishName"].ToString(), reader["ProductCount"]);
                            }

                            // Открываем форму для отображения результатов
                            QueryResultsForm resultsForm = new QueryResultsForm(resultsTable, mainForm);
                            resultsForm.Show(); // Используйте ShowDialog() для модального окна
                        }
                        else
                        {
                            MessageBox.Show("Не найдено блюд с продуктами категории 'Пряность'.");
                        }
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
            // Удаляем все существующие DataGridView
            foreach (Control control in this.Controls.OfType<DataGridView>().ToList())
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

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

                    // Открываем результаты в новом окне
                    QueryResultsForm resultsForm = new QueryResultsForm(dataTable, mainForm);
                    resultsForm.Show(); // Можно использовать ShowDialog() для модального окнаe;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }

        private void paramQuery_Click(object sender, EventArgs e)
        {
            // Удаляем все существующие DataGridView
            foreach (Control control in this.Controls.OfType<DataGridView>().ToList())
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

            // Получаем значение из текстового поля (например, для категории блюда)
            string categoryName = categoryTextBox.Text?.Trim(); // Убираем лишние пробелы

            // Проверяем, что пользователь ввел значение
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Пожалуйста, введите категорию блюда.");
                return;
            }

            // Проверяем, что значение состоит только из букв (можно дополнить другими условиями)
            if (!categoryName.All(char.IsLetter))
            {
                MessageBox.Show("Название категории должно содержать только буквы.");
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
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                        // Выполняем запрос и читаем результат
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("По указанной категории блюда ничего не найдено.");
                                return;
                            }

                            DataTable table = new DataTable();
                            table.Load(reader);

                            // Открываем результаты в новом окне
                            QueryResultsForm resultsForm = new QueryResultsForm(table, mainForm);
                            resultsForm.Show(); // Можно использовать ShowDialog() для модального окна
                        }
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show($"Ошибка работы с базой данных: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения параметрического запроса: {ex.Message}");
                }
            }
        }



        private void crossQuery_Click(object sender, EventArgs e)
        {
            // Удаляем все существующие DataGridView
            foreach (Control control in this.Controls.OfType<DataGridView>().ToList())
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

            // Получаем значение минимальной стоимости из TextBox
            string minCostInput = minCostTextBox.Text?.Trim(); // Убираем пробелы

            // Проверяем, что пользователь ввел значение
            if (string.IsNullOrWhiteSpace(minCostInput))
            {
                MessageBox.Show("Пожалуйста, введите минимальную стоимость.");
                return;
            }

            // Проверяем, что введено корректное число
            if (!decimal.TryParse(minCostInput, out decimal minCost) || minCost < 0)
            {
                MessageBox.Show("Введите корректное положительное число для минимальной стоимости.");
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Перекрестный запрос для вычисления общей стоимости продуктов в каждом блюде
                    string query = @"
                SELECT d.Name AS DishName, 
                       SUM(dc.Quantity * p.PricePerUnit) AS TotalCost
                FROM Dish AS d
                JOIN DishComposition AS dc ON d.DishID = dc.DishID
                JOIN Product AS p ON dc.ProductID = p.ProductID
                GROUP BY d.Name
                HAVING TotalCost > @MinCost";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Добавляем параметр с минимальной стоимостью
                        cmd.Parameters.AddWithValue("@MinCost", minCost);

                        // Выполняем запрос и читаем результат
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Нет блюд с общей стоимостью выше заданного минимума.");
                                return;
                            }

                            DataTable table = new DataTable();
                            table.Load(reader);

                            // Открываем результаты в новом окне
                            QueryResultsForm resultsForm = new QueryResultsForm(table, mainForm);
                            resultsForm.Show(); // Можно использовать ShowDialog() для модального окна
                        }
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show($"Ошибка работы с базой данных: {sqlEx.Message}");
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

        private void minCostTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(minCostTextBox.Text))
            {
                minCostTextBox.Text = "Введите минимальную стоимость...";
            }
        }

        private void minCostTextBox_Enter(object sender, EventArgs e)
        {
            if (minCostTextBox.Text == "Введите минимальную стоимость...")
            {
                minCostTextBox.Text = "";

            }
        }

        private void categoryTextBox_Enter(object sender, EventArgs e)
        {
            if (categoryTextBox.Text == "Введите категорию...")
            {
                categoryTextBox.Text = "";

            }
        }

        private void categoryTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                categoryTextBox.Text = "Введите категорию...";
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
