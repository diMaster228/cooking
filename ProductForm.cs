using System;
using System.Windows.Forms;
using System.Drawing;

namespace cooking
{
    public partial class ProductForm : BaseFormWithMaterial
    {
        private DishDAL dishDAL = new DishDAL(); // Класс для работы с данными
        private MainForm mainForm; // Ссылка на главную форму
        private ReportForm reportForm; // Ссылка на форму отчетов
        private DishForm dishForm;

        // Конструктор формы с передачей зависимостей
        public ProductForm(MainForm mainForm, ReportForm reportForm = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mainForm.ThemeChanged += UpdateTheme;
            UpdateTheme(mainForm.IsDarkModeChecked());
            this.reportForm = reportForm;
            LoadProducts(); // Загрузка данных при открытии формы
        }

        // Переопределенный метод для обновления темы
        // Переопределенный метод для обновления темы
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



        // Метод для загрузки продуктов
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = dishDAL.GetAllProducts(); // Загрузка данных в DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}");
            }
        }

        // Обработчик кнопки для перехода на форму DishForm
        private void btnToDishForm_Click(object sender, EventArgs e)
        {
            if (dishForm == null)
                dishForm = new DishForm(mainForm);

            this.Hide();
            dishForm.Show();
        }

        // Обработчик кнопки для перехода на главную форму
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

        // Обработчик кнопки для перехода на форму ReportForm
        private void btnToReportForm_Click(object sender, EventArgs e)
        {
            if (reportForm == null)
                reportForm = new ReportForm(mainForm);

            this.Hide();
            reportForm.Show();
        }
    }
}
