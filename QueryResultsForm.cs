using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cooking
{
    public partial class QueryResultsForm : BaseFormWithMaterial
    {
        private MainForm mainForm;
        private DataTable data;

        public QueryResultsForm(DataTable data, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.data = data;
            this.mainForm.ThemeChanged += UpdateTheme;
            UpdateTheme(mainForm.IsDarkModeChecked());

            // Привязка таблицы к DataGridView
            dgvResults.DataSource = data;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (mainForm != null)
            {
                mainForm.ThemeChanged -= UpdateTheme;
            }
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


    }
}
