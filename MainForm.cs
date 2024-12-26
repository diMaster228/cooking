using System;
using System.Windows.Forms;

namespace cooking
{
    public partial class MainForm : BaseMaterialForm
    {
        public MainForm()
        {
            InitializeComponent(); // �������� ����� �� MainForm.Designer.cs
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
                "�� �������, ��� ������ ��������� ���������?",
                "������������� ������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit(); // ���������� ���������
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(this); // �������� ������� �����
            productForm.Show();
            this.Hide();

            // ������� � MainForm ��� �������� ProductForm
            productForm.FormClosed += (s, args) => this.Show();
        }

        
    }
}
