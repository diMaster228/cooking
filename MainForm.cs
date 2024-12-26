using System;
using System.Windows.Forms;

namespace cooking
{
    public partial class MainForm : BaseMaterialForm
    {
        public MainForm()
        {
            InitializeComponent(); // Вызывает метод из MainForm.Designer.cs
            btnExit.Click += BtnExit_Click;
        }

        private void btnViewDishes_Click(object sender, EventArgs e)
        {
            DishForm dishForm = new DishForm(this);
            this.Hide();
            dishForm.ShowDialog();
        }


        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(this);
            this.Hide();
            reportForm.ShowDialog();
        }

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

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(this); // Передаем текущую форму
            productForm.Show();
            this.Hide();

            // Возврат к MainForm при закрытии ProductForm
            productForm.FormClosed += (s, args) => this.Show();
        }

        
    }
}
