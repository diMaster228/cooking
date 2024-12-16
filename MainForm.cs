using System;
using System.Windows.Forms;
using Data;


namespace cooking
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void btnViewDishes_Click(object sender, EventArgs e)
        {
            DishForm dishForm = new DishForm();
            dishForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }
    }
}
