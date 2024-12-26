namespace cooking
{
    partial class ReportForm
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
            this.crossQuery = new MaterialSkin.Controls.MaterialFlatButton();
            this.paramQuery = new MaterialSkin.Controls.MaterialFlatButton();
            this.query4 = new MaterialSkin.Controls.MaterialFlatButton();
            this.query3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.query2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.query1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnToProductForm = new System.Windows.Forms.Button();
            this.btnToDishForm = new System.Windows.Forms.Button();
            this.btnToMainForm = new System.Windows.Forms.Button();
            this.lblReportResult = new System.Windows.Forms.Label();
            this.btnDishCount = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.minCostTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crossQuery
            // 
            this.crossQuery.AutoSize = true;
            this.crossQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crossQuery.Depth = 0;
            this.crossQuery.Icon = null;
            this.crossQuery.Location = new System.Drawing.Point(544, 259);
            this.crossQuery.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.crossQuery.MouseState = MaterialSkin.MouseState.HOVER;
            this.crossQuery.Name = "crossQuery";
            this.crossQuery.Primary = false;
            this.crossQuery.Size = new System.Drawing.Size(230, 36);
            this.crossQuery.TabIndex = 10;
            this.crossQuery.Text = "перекрестный запрос";
            this.crossQuery.UseVisualStyleBackColor = true;
            this.crossQuery.Click += new System.EventHandler(this.crossQuery_Click);
            // 
            // paramQuery
            // 
            this.paramQuery.AutoSize = true;
            this.paramQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.paramQuery.Depth = 0;
            this.paramQuery.Icon = null;
            this.paramQuery.Location = new System.Drawing.Point(516, 188);
            this.paramQuery.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.paramQuery.MouseState = MaterialSkin.MouseState.HOVER;
            this.paramQuery.Name = "paramQuery";
            this.paramQuery.Primary = false;
            this.paramQuery.Size = new System.Drawing.Size(267, 36);
            this.paramQuery.TabIndex = 9;
            this.paramQuery.Text = "параметрический запрос";
            this.paramQuery.UseVisualStyleBackColor = true;
            this.paramQuery.Click += new System.EventHandler(this.paramQuery_Click);
            // 
            // query4
            // 
            this.query4.AutoSize = true;
            this.query4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.query4.Depth = 0;
            this.query4.Icon = null;
            this.query4.Location = new System.Drawing.Point(70, 206);
            this.query4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.query4.MouseState = MaterialSkin.MouseState.HOVER;
            this.query4.Name = "query4";
            this.query4.Primary = false;
            this.query4.Size = new System.Drawing.Size(114, 36);
            this.query4.TabIndex = 8;
            this.query4.Text = "выборка4";
            this.query4.UseVisualStyleBackColor = true;
            this.query4.Click += new System.EventHandler(this.query4_Click);
            // 
            // query3
            // 
            this.query3.AutoSize = true;
            this.query3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.query3.Depth = 0;
            this.query3.Icon = null;
            this.query3.Location = new System.Drawing.Point(302, 206);
            this.query3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.query3.MouseState = MaterialSkin.MouseState.HOVER;
            this.query3.Name = "query3";
            this.query3.Primary = false;
            this.query3.Size = new System.Drawing.Size(114, 36);
            this.query3.TabIndex = 7;
            this.query3.Text = "выборка3";
            this.query3.UseVisualStyleBackColor = true;
            this.query3.Click += new System.EventHandler(this.query3_Click);
            // 
            // query2
            // 
            this.query2.AutoSize = true;
            this.query2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.query2.Depth = 0;
            this.query2.Icon = null;
            this.query2.Location = new System.Drawing.Point(302, 122);
            this.query2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.query2.MouseState = MaterialSkin.MouseState.HOVER;
            this.query2.Name = "query2";
            this.query2.Primary = false;
            this.query2.Size = new System.Drawing.Size(114, 36);
            this.query2.TabIndex = 6;
            this.query2.Text = "выборка2";
            this.query2.UseVisualStyleBackColor = true;
            this.query2.Click += new System.EventHandler(this.query2_Click);
            // 
            // query1
            // 
            this.query1.AutoSize = true;
            this.query1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.query1.Depth = 0;
            this.query1.Icon = null;
            this.query1.Location = new System.Drawing.Point(70, 122);
            this.query1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.query1.MouseState = MaterialSkin.MouseState.HOVER;
            this.query1.Name = "query1";
            this.query1.Primary = false;
            this.query1.Size = new System.Drawing.Size(114, 36);
            this.query1.TabIndex = 5;
            this.query1.Text = "выборка1";
            this.query1.UseVisualStyleBackColor = true;
            this.query1.Click += new System.EventHandler(this.query1_Click);
            // 
            // btnToProductForm
            // 
            this.btnToProductForm.Location = new System.Drawing.Point(245, 470);
            this.btnToProductForm.Name = "btnToProductForm";
            this.btnToProductForm.Size = new System.Drawing.Size(134, 61);
            this.btnToProductForm.TabIndex = 4;
            this.btnToProductForm.Text = "Перейти к продуктам";
            this.btnToProductForm.UseVisualStyleBackColor = true;
            this.btnToProductForm.Click += new System.EventHandler(this.btnToProductForm_Click);
            // 
            // btnToDishForm
            // 
            this.btnToDishForm.Location = new System.Drawing.Point(492, 482);
            this.btnToDishForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToDishForm.Name = "btnToDishForm";
            this.btnToDishForm.Size = new System.Drawing.Size(176, 37);
            this.btnToDishForm.TabIndex = 3;
            this.btnToDishForm.Text = "Перейти к блюдам";
            this.btnToDishForm.UseVisualStyleBackColor = true;
            this.btnToDishForm.Click += new System.EventHandler(this.btnToDishForm_Click);
            // 
            // btnToMainForm
            // 
            this.btnToMainForm.Location = new System.Drawing.Point(802, 482);
            this.btnToMainForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToMainForm.Name = "btnToMainForm";
            this.btnToMainForm.Size = new System.Drawing.Size(150, 37);
            this.btnToMainForm.TabIndex = 2;
            this.btnToMainForm.Text = "На главную форму";
            this.btnToMainForm.UseVisualStyleBackColor = true;
            this.btnToMainForm.Click += new System.EventHandler(this.btnToMainForm_Click);
            // 
            // lblReportResult
            // 
            this.lblReportResult.AutoSize = true;
            this.lblReportResult.Location = new System.Drawing.Point(67, 98);
            this.lblReportResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportResult.Name = "lblReportResult";
            this.lblReportResult.Size = new System.Drawing.Size(0, 16);
            this.lblReportResult.TabIndex = 1;
            // 
            // btnDishCount
            // 
            this.btnDishCount.Location = new System.Drawing.Point(544, 88);
            this.btnDishCount.Margin = new System.Windows.Forms.Padding(4);
            this.btnDishCount.Name = "btnDishCount";
            this.btnDishCount.Size = new System.Drawing.Size(200, 37);
            this.btnDishCount.TabIndex = 0;
            this.btnDishCount.Text = "Количество блюд";
            this.btnDishCount.UseVisualStyleBackColor = true;
            this.btnDishCount.Click += new System.EventHandler(this.btnDishCount_Click);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(802, 195);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(157, 22);
            this.categoryTextBox.TabIndex = 11;
            this.categoryTextBox.Text = "Введите категорию ";
            this.categoryTextBox.TextChanged += new System.EventHandler(this.categoryTextBox_TextChanged);
            // 
            // minCostTextBox
            // 
            this.minCostTextBox.Location = new System.Drawing.Point(802, 266);
            this.minCostTextBox.Name = "minCostTextBox";
            this.minCostTextBox.Size = new System.Drawing.Size(233, 22);
            this.minCostTextBox.TabIndex = 12;
            this.minCostTextBox.Text = "Введите мин стоимость";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 764);
            this.Controls.Add(this.minCostTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.crossQuery);
            this.Controls.Add(this.paramQuery);
            this.Controls.Add(this.query4);
            this.Controls.Add(this.query3);
            this.Controls.Add(this.query2);
            this.Controls.Add(this.query1);
            this.Controls.Add(this.btnToProductForm);
            this.Controls.Add(this.btnToDishForm);
            this.Controls.Add(this.btnToMainForm);
            this.Controls.Add(this.lblReportResult);
            this.Controls.Add(this.btnDishCount);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportForm";
            this.Text = "Отчёты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDishCount;
        private System.Windows.Forms.Label lblReportResult;
        private System.Windows.Forms.Button btnToMainForm;
        private System.Windows.Forms.Button btnToDishForm;
        private System.Windows.Forms.Button btnToProductForm;
        private MaterialSkin.Controls.MaterialFlatButton query1;
        private MaterialSkin.Controls.MaterialFlatButton query2;
        private MaterialSkin.Controls.MaterialFlatButton query3;
        private MaterialSkin.Controls.MaterialFlatButton query4;
        private MaterialSkin.Controls.MaterialFlatButton paramQuery;
        private MaterialSkin.Controls.MaterialFlatButton crossQuery;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox minCostTextBox;
    }
}
