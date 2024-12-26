using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace cooking
{
    public partial class DishForm : BaseMaterialForm
    {
        private DishDAL dishDAL = new DishDAL();
        private MainForm mainForm; // Ссылка на главную форму
        private ReportForm reportForm; // Ссылка на форму отчетов
        private ProductForm productForm;

        public DishForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadDishes();

            // Установить текст по умолчанию
            txtName.Text = "Введите название блюда...";
            txtCategory.Text = "Введите категорию...";
            txtRecipe.Text = "Введите рецепт...";
            txtPortionWeight.Text = "Введите вес порциии...";

            // Добавляем обработчики событий для очистки текста по умолчанию
            txtName.Enter += TxtName_Enter;
            txtCategory.Enter += txtCategory_Enter;
            txtRecipe.Enter += TxtRecipe_Enter;
            txtPortionWeight.Enter += txtPortionWeight_Enter;

            // Добавляем обработчики событий для восстановления текста по умолчанию
            txtName.Leave += TxtName_Leave;
            txtCategory.Leave += TxtCategory_Leave;
            txtRecipe.Leave += TxtRecipe_Leave;
            txtPortionWeight.Leave += txtPortionWeight_Leave;
        }

        private void btnToMainForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
        }

        private void btnToReportForm_Click(object sender, EventArgs e)
        {
            if (reportForm == null) reportForm = new ReportForm(mainForm);
            this.Hide();
            reportForm.Show();
        }

        private void LoadDishes()
        {
            dgvDishes.DataSource = dishDAL.GetAllDishes();
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            // Проверка формата веса порции
            decimal portionWeight;
            if (!decimal.TryParse(txtPortionWeight.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out portionWeight))
            {
                MessageBox.Show($"Введите корректное значение для 'Вес порции' (например: {150.00.ToString(CultureInfo.CurrentCulture)}).");
                return;
            }

            // Проверка остальных полей
            string name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Поле 'Название' не должно быть пустым.");
                return;
            }

            string category = txtCategory.Text;
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Полеи 'Категория' не должно быть пустым.");
                return;
            }

            string recipe = txtRecipe.Text;
            if (string.IsNullOrWhiteSpace(recipe))
            {
                MessageBox.Show("Поле 'Рецепт' не должно быть пустым.");
                return;
            }

            // Подтверждение добавления
            var confirmResult = MessageBox.Show(
                "Вы уверены, что хотите добавить выбранное блюдо?",
                "Подтверждение добавления",
                MessageBoxButtons.YesNo
            );

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            // Попытка добавления блюда
            try
            {
                dishDAL.AddDish(name, category, recipe, portionWeight);
                MessageBox.Show("Блюдо добавлено!");
                LoadDishes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении блюда: {ex.Message}");
            }
        }
        


        private void btnEditDish_Click(object sender, EventArgs e)
        {
            // Проверяем, выделена ли строка в DataGridView
            if (dgvDishes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо для редактирования.");
                return;
            }

            // Проверяем остальные поля
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Поле 'Название' не должно быть пустым.");
                return;
            }

            string category = txtCategory.Text.Trim();
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Поле 'Категория' не должно быть пустым.");
                return;
            }

            string recipe = txtRecipe.Text.Trim();
            if (string.IsNullOrWhiteSpace(recipe))
            {
                MessageBox.Show("Поле 'Рецепт' не должно быть пустым.");
                return;
            }

            // Проверяем формат веса порции
            if (!decimal.TryParse(txtPortionWeight.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal portionWeight) || portionWeight <= 0)
            {
                MessageBox.Show($"Введите корректное значение для 'Вес порции' (например: {150.00.ToString(CultureInfo.CurrentCulture)}).");
                return;
            }

            // Получаем ID выбранного блюда
            int dishId;
            try
            {
                dishId = Convert.ToInt32(dgvDishes.SelectedRows[0].Cells["DishID"].Value);
            }
            catch
            {
                MessageBox.Show("Ошибка получения идентификатора блюда. Проверьте выделенную строку.");
                return;
            }

            // Подтверждаем редактирование
            var confirmResult = MessageBox.Show(
                "Вы уверены, что хотите сохранить изменения?",
                "Подтверждение редактирования",
                MessageBoxButtons.YesNo
            );

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            // Попытка редактирования блюда
            try
            {
                dishDAL.UpdateDish(dishId, name, category, recipe, portionWeight);
                MessageBox.Show("Блюдо успешно обновлено!");
                LoadDishes(); // Обновление списка блюд в интерфейсе
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось обновить блюдо: {ex.Message}");
            }
        }



        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            // Проверяем, выделена ли строка в DataGridView
            if (dgvDishes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо для удаления.");
                return;
            }

            // Извлекаем ID блюда из выбранной строки
            int dishId = Convert.ToInt32(dgvDishes.SelectedRows[0].Cells["DishID"].Value);

            // Подтверждаем удаление
            var confirmResult = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранное блюдо?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo
            );

            if (confirmResult == DialogResult.Yes)
            {
                // Вызываем метод для удаления блюда
                dishDAL.DeleteDish(dishId);

                // Обновляем список блюд
                MessageBox.Show("Блюдо удалено!");
                LoadDishes();
            }
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DishForm_Load(object sender, EventArgs e)
        {

        }

        private void txtRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDishes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDishes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnToProductForm_Click(object sender, EventArgs e)
        {
            if (productForm == null)
                productForm = new ProductForm(mainForm); // Передаем MainForm

            this.Hide();
            productForm.Show();
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Введите название блюда...")
            {
                txtName.Text = "";
            }
        }

        private void txtCategory_Enter(object sender, EventArgs e)
        {
            if (txtCategory.Text == "Введите категорию...")
            {
                txtCategory.Text = "";
            }
        }

        private void TxtRecipe_Enter(object sender, EventArgs e)
        {
            if (txtRecipe.Text == "Введите рецепт...")
            {
                txtRecipe.Text = "";
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Введите название блюда...";
            }
        }

        private void TxtCategory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                txtCategory.Text = "Введите категорию...";
            }
        }

        private void TxtRecipe_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipe.Text))
            {
                txtRecipe.Text = "Введите рецепт...";
            }
        }

        private void txtPortionWeight_Enter(object sender, EventArgs e)
        {
            if (txtPortionWeight.Text == "Введите вес порциии...")
            {
                txtPortionWeight.Text = "";
                
            }
        }

        private void txtPortionWeight_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPortionWeight.Text))
            {
                txtPortionWeight.Text = "Введите вес порциии...";
            }
        }
    }
}
