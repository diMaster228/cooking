using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace cooking
{
    public class BaseFormWithMaterial : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public BaseFormWithMaterial()
        {
            // Инициализация MaterialSkinManager для управления темами
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Изначальная настройка темы: светлая или темная
            UpdateTheme(false); // Изначально светлая тема

            // Настройка темы по умолчанию
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // или DARK
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
        }

        // Метод для обновления темы в зависимости от флага isDarkMode
        public virtual void UpdateTheme(bool isDarkMode)
        {
            // Применяем стили Material Design в зависимости от текущей темы
            if (isDarkMode)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey800, Primary.Grey600, Accent.Red200, TextShade.WHITE);
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
            }

            // Обновление всех элементов управления в соответствии с выбранной темой
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    // Применяем цвета к кнопкам
                    button.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : SystemColors.Control;
                    button.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is Label label)
                {
                    // Применяем цвета к меткам
                    label.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is TextBox textBox)
                {
                    // Применяем цвета к текстовым полям
                    textBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    textBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (control is ComboBox comboBox)
                {
                    // Применяем цвета к комбинированным полям
                    comboBox.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                    comboBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
            }
        }
    }
}
