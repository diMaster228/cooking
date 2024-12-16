using cooking;
using System;
using System.Windows.Forms;
using Data;


namespace cooking
{
    public partial class DishForm : Form
    {
        private DishDAL dishDAL = new DishDAL();

        public DishForm()
        {
            InitializeComponent();
            LoadDishes();
        }

        private void LoadDishes()
        {
            dgvDishes.DataSource = dishDAL.GetAllDishes();
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string category = txtCategory.Text;
            string recipe = txtRecipe.Text;
            decimal portionWeight = decimal.Parse(txtPortionWeight.Text);

            dishDAL.AddDish(name, category, recipe, portionWeight);
            MessageBox.Show("Блюдо добавлено!");
            LoadDishes();
        }

        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            int dishId = Convert.ToInt32(dgvDishes.SelectedRows[0].Cells["DishID"].Value);

            dishDAL.DeleteDish(dishId);
            MessageBox.Show("Блюдо удалено!");
            LoadDishes();
        }
    }
}
