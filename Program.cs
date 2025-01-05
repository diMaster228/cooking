using System;
using System.Windows.Forms;
using cooking;
using MaterialSkin;
using MaterialSkin.Controls;

namespace cooking
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Настроим MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;  // Здесь устанавливаем темную тему
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            // Запускаем главную форму
            Application.Run(new MainForm());  // Запускаем вашу главную форму
        }
    }
}
