using System;
using System.Windows.Forms;
using System.Drawing;

namespace cooking
{
    public partial class MainForm : BaseFormWithMaterial
    {
        public MainForm()
        {
            InitializeComponent(); // Вызывает метод из MainForm.Designer.cs
            btnExit.Click += BtnExit_Click;

            themeToggle.CheckedChanged += themeToggle_CheckedChanged;

            // Настройка подсказок для кнопок
            toolTip1.SetToolTip(btnExit, "Завершить программу");
            toolTip1.SetToolTip(btnViewDishes, "Открыть список блюд");
            toolTip1.SetToolTip(btnReports, "Просмотреть отчеты");
            toolTip1.SetToolTip(btnViewProducts, "Открыть список продуктов");

            // Подписываемся на событие Popup
            toolTip1.Popup += toolTip1_Popup;
        }

        public event Action<bool> ThemeChanged;

        // В MainForm
        public bool IsDarkModeChecked()
        {
            return themeToggle.Checked;
        }


        // Обработчик для кнопки "Список блюд"
        private void btnViewDishes_Click(object sender, EventArgs e)
        {
            DishForm dishForm = new DishForm(this);
            this.Hide();
            dishForm.ShowDialog();
        }

        // Обработчик для кнопки "Просмотр отчетов"
        private void btnReports_Click(object sender, EventArgs e)
        {
            // Создаем объект формы отчетов
            ReportForm reportForm = new ReportForm(this);

            // Прячем текущую форму (MainForm)
            this.Hide();

            // Показываем форму отчетов
            reportForm.ShowDialog();

            // Обработчик события FormClosed, срабатывает после закрытия ReportForm
            reportForm.FormClosed += (s, args) =>
            {
                this.Show(); // Показываем главную форму
                this.UpdateTheme(themeToggle.Checked); // Применяем тему на главной форме
            };
        }


        // Обработчик для кнопки "Список продуктов"
        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(this); // Передаем текущую форму
            productForm.Show();
            this.Hide();

            productForm.UpdateTheme(themeToggle.Checked);

            // Возврат к MainForm при закрытии ProductForm
            productForm.FormClosed += (s, args) => this.Show();
        }

        // Пустая реализация, можно добавить нужный код для подсказок
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        // Обработчик изменения состояния чекбокса для темы
        private void themeToggle_CheckedChanged(object sender, EventArgs e)
        {
            bool isDarkMode = themeToggle.Checked;

            // Обновление темы на текущей форме
            UpdateTheme(isDarkMode);

            // Обновление темы на других открытых формах
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is BaseFormWithMaterial form) // Обновляем только формы, наследующие от BaseForm
                {
                    form.UpdateTheme(isDarkMode);
                }
            }

            ThemeChanged?.Invoke(isDarkMode);
        }


        // Метод для обновления темы на текущей форме
        public override void UpdateTheme(bool isDarkMode)
        {
            base.UpdateTheme(isDarkMode); // Вызов метода из BaseForm для применения темы

            // Обновление цветов для всех элементов управления на форме
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            // Обновление цветов кнопок
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : SystemColors.Control;
                    button.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is Label label)
                {
                    label.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    textBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    comboBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                // Добавьте другие элементы управления по мере необходимости
            }
        }

        // Обработчик для кнопки "Выход"
        private void BtnExit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Вы уверены, что хотите завершить программу?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit(); // Завершение программы
            }
        }
    }
}
