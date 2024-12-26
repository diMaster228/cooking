namespace cooking
{
    partial class DishForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка всех используемых ресурсов.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDishes = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtRecipe = new System.Windows.Forms.TextBox();
            this.txtPortionWeight = new System.Windows.Forms.TextBox();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.btnDeleteDish = new System.Windows.Forms.Button();
            this.btnToMainForm = new System.Windows.Forms.Button();
            this.btnToReportForm = new System.Windows.Forms.Button();
            this.btnEditDish = new System.Windows.Forms.Button();
            this.btnToProductForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDishes
            // 
            this.dgvDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDishes.Location = new System.Drawing.Point(24, 81);
            this.dgvDishes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDishes.Name = "dgvDishes";
            this.dgvDishes.RowHeadersWidth = 51;
            this.dgvDishes.Size = new System.Drawing.Size(585, 234);
            this.dgvDishes.TabIndex = 0;
            this.dgvDishes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDishes_CellContentClick_1);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(24, 356);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 22);
            this.txtName.TabIndex = 1;
            this.txtName.Enter += new System.EventHandler(this.TxtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.TxtName_Leave);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(165, 356);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(132, 22);
            this.txtCategory.TabIndex = 2;
            this.txtCategory.Enter += new System.EventHandler(this.txtCategory_Enter);
            this.txtCategory.Leave += new System.EventHandler(this.TxtCategory_Leave);
            // 
            // txtRecipe
            // 
            this.txtRecipe.Location = new System.Drawing.Point(307, 356);
            this.txtRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecipe.Name = "txtRecipe";
            this.txtRecipe.Size = new System.Drawing.Size(132, 22);
            this.txtRecipe.TabIndex = 3;
            this.txtRecipe.Enter += new System.EventHandler(this.TxtRecipe_Enter);
            this.txtRecipe.Leave += new System.EventHandler(this.TxtRecipe_Leave);
            // 
            // txtPortionWeight
            // 
            this.txtPortionWeight.Location = new System.Drawing.Point(448, 356);
            this.txtPortionWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtPortionWeight.Name = "txtPortionWeight";
            this.txtPortionWeight.Size = new System.Drawing.Size(132, 22);
            this.txtPortionWeight.TabIndex = 4;
            this.txtPortionWeight.Enter += new System.EventHandler(this.txtPortionWeight_Enter);
            this.txtPortionWeight.Leave += new System.EventHandler(this.txtPortionWeight_Leave);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(24, 393);
            this.btnAddDish.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(133, 37);
            this.btnAddDish.TabIndex = 5;
            this.btnAddDish.Text = "Добавить";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Location = new System.Drawing.Point(165, 393);
            this.btnDeleteDish.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Size = new System.Drawing.Size(133, 37);
            this.btnDeleteDish.TabIndex = 6;
            this.btnDeleteDish.Text = "Удалить";
            this.btnDeleteDish.UseVisualStyleBackColor = true;
            this.btnDeleteDish.Click += new System.EventHandler(this.btnDeleteDish_Click);
            // 
            // btnToMainForm
            // 
            this.btnToMainForm.Location = new System.Drawing.Point(448, 393);
            this.btnToMainForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToMainForm.Name = "btnToMainForm";
            this.btnToMainForm.Size = new System.Drawing.Size(133, 37);
            this.btnToMainForm.TabIndex = 7;
            this.btnToMainForm.Text = "На главную";
            this.btnToMainForm.UseVisualStyleBackColor = true;
            this.btnToMainForm.Click += new System.EventHandler(this.btnToMainForm_Click);
            // 
            // btnToReportForm
            // 
            this.btnToReportForm.Location = new System.Drawing.Point(24, 455);
            this.btnToReportForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToReportForm.Name = "btnToReportForm";
            this.btnToReportForm.Size = new System.Drawing.Size(133, 37);
            this.btnToReportForm.TabIndex = 8;
            this.btnToReportForm.Text = "К отчетам";
            this.btnToReportForm.UseVisualStyleBackColor = true;
            this.btnToReportForm.Click += new System.EventHandler(this.btnToReportForm_Click);
            // 
            // btnEditDish
            // 
            this.btnEditDish.Location = new System.Drawing.Point(308, 393);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(133, 37);
            this.btnEditDish.TabIndex = 9;
            this.btnEditDish.Text = "Изменить";
            this.btnEditDish.UseVisualStyleBackColor = true;
            this.btnEditDish.Click += new System.EventHandler(this.btnEditDish_Click);
            // 
            // btnToProductForm
            // 
            this.btnToProductForm.Location = new System.Drawing.Point(165, 455);
            this.btnToProductForm.Name = "btnToProductForm";
            this.btnToProductForm.Size = new System.Drawing.Size(111, 37);
            this.btnToProductForm.TabIndex = 10;
            this.btnToProductForm.Text = "К продуктам";
            this.btnToProductForm.UseVisualStyleBackColor = true;
            this.btnToProductForm.Click += new System.EventHandler(this.btnToProductForm_Click);
            // 
            // DishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 779);
            this.Controls.Add(this.btnToProductForm);
            this.Controls.Add(this.btnEditDish);
            this.Controls.Add(this.btnDeleteDish);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.txtPortionWeight);
            this.Controls.Add(this.txtRecipe);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgvDishes);
            this.Controls.Add(this.btnToMainForm);
            this.Controls.Add(this.btnToReportForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DishForm";
            this.Text = "Управление блюдами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDishes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtRecipe;
        private System.Windows.Forms.TextBox txtPortionWeight;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Button btnDeleteDish;
        private System.Windows.Forms.Button btnToMainForm;
        private System.Windows.Forms.Button btnToReportForm;
        private System.Windows.Forms.Button btnEditDish;
        private System.Windows.Forms.Button btnToProductForm;
    }
}