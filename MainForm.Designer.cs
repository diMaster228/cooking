namespace cooking
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnViewDishes = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewProducts = new System.Windows.Forms.Button();
            this.themeToggle = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnViewDishes
            // 
            this.btnViewDishes.Location = new System.Drawing.Point(25, 40);
            this.btnViewDishes.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewDishes.Name = "btnViewDishes";
            this.btnViewDishes.Size = new System.Drawing.Size(177, 77);
            this.btnViewDishes.TabIndex = 0;
            this.btnViewDishes.Text = "Просмотреть блюда";
            this.btnViewDishes.UseVisualStyleBackColor = true;
            this.btnViewDishes.Click += new System.EventHandler(this.btnViewDishes_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(254, 40);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(177, 77);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(254, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(177, 77);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnViewProducts
            // 
            this.btnViewProducts.Location = new System.Drawing.Point(25, 196);
            this.btnViewProducts.Name = "btnViewProducts";
            this.btnViewProducts.Size = new System.Drawing.Size(177, 77);
            this.btnViewProducts.TabIndex = 4;
            this.btnViewProducts.Text = "Просмотреть продукты";
            this.btnViewProducts.UseVisualStyleBackColor = true;
            this.btnViewProducts.Click += new System.EventHandler(this.btnViewProducts_Click);
            // 
            // themeToggle
            // 
            this.themeToggle.AutoSize = true;
            this.themeToggle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.themeToggle.Location = new System.Drawing.Point(0, 319);
            this.themeToggle.Name = "themeToggle";
            this.themeToggle.Size = new System.Drawing.Size(466, 20);
            this.themeToggle.TabIndex = 5;
            this.themeToggle.Text = "Темная тема";
            this.themeToggle.UseVisualStyleBackColor = true;
            this.themeToggle.CheckedChanged += new System.EventHandler(this.themeToggle_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 339);
            this.Controls.Add(this.themeToggle);
            this.Controls.Add(this.btnViewProducts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnViewDishes);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewDishes;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewProducts;
        private System.Windows.Forms.CheckBox themeToggle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}