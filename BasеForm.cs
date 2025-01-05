using System;
using System.Drawing;
using System.Windows.Forms;

namespace cooking
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Устанавливаем начальное состояние темы
            UpdateTheme(false); // Изначально светлая тема
        }

        // Метод для обновления темы
        public virtual void UpdateTheme(bool isDarkMode)
        {
            // Обновление основного фона формы
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            // Обновление цветов элементов управления
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
    }
}
