using System;
using System.Windows.Forms;

namespace cooking
{
    public partial class ProductForm : BaseMaterialForm
    {
        private DishDAL dishDAL = new DishDAL(); // Класс для работы с данными
        private MainForm mainForm; // Ссылка на главную форму
        private ReportForm reportForm; // Ссылка на форму отчетов
        private DishForm dishForm;

        public ProductForm(MainForm mainForm, ReportForm reportForm = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.reportForm = reportForm;
            LoadProducts(); // Загрузка данных при открытии формы
        }

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

        private void btnToDishForm_Click(object sender, EventArgs e)
        {
            if (dishForm == null)
                dishForm = new DishForm(mainForm);

            this.Hide();
            dishForm.Show();
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

        private void btnToReportForm_Click(object sender, EventArgs e)
        {
            if (reportForm == null)
                reportForm = new ReportForm(mainForm);

            this.Hide();
            reportForm.Show();
        }
    }
}


