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
            this.btnToProductForm = new System.Windows.Forms.Button();
            this.btnToDishForm = new System.Windows.Forms.Button();
            this.btnToMainForm = new System.Windows.Forms.Button();
            this.lblReportResult = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.minCostTextBox = new System.Windows.Forms.TextBox();
            this.query1 = new System.Windows.Forms.Button();
            this.query2 = new System.Windows.Forms.Button();
            this.query3 = new System.Windows.Forms.Button();
            this.query4 = new System.Windows.Forms.Button();
            this.paramQuery = new System.Windows.Forms.Button();
            this.crossQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToProductForm
            // 
            this.btnToProductForm.Location = new System.Drawing.Point(56, 542);
            this.btnToProductForm.Name = "btnToProductForm";
            this.btnToProductForm.Size = new System.Drawing.Size(176, 61);
            this.btnToProductForm.TabIndex = 4;
            this.btnToProductForm.Text = "Перейти к продуктам";
            this.btnToProductForm.UseVisualStyleBackColor = true;
            this.btnToProductForm.Click += new System.EventHandler(this.btnToProductForm_Click);
            // 
            // btnToDishForm
            // 
            this.btnToDishForm.Location = new System.Drawing.Point(268, 542);
            this.btnToDishForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToDishForm.Name = "btnToDishForm";
            this.btnToDishForm.Size = new System.Drawing.Size(176, 61);
            this.btnToDishForm.TabIndex = 3;
            this.btnToDishForm.Text = "Перейти к блюдам";
            this.btnToDishForm.UseVisualStyleBackColor = true;
            this.btnToDishForm.Click += new System.EventHandler(this.btnToDishForm_Click);
            // 
            // btnToMainForm
            // 
            this.btnToMainForm.Location = new System.Drawing.Point(480, 542);
            this.btnToMainForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnToMainForm.Name = "btnToMainForm";
            this.btnToMainForm.Size = new System.Drawing.Size(176, 61);
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
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(394, 459);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(262, 22);
            this.categoryTextBox.TabIndex = 11;
            this.categoryTextBox.Text = " ";
            this.categoryTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.categoryTextBox.TextChanged += new System.EventHandler(this.categoryTextBox_TextChanged);
            this.categoryTextBox.Enter += new System.EventHandler(this.categoryTextBox_Enter);
            this.categoryTextBox.Leave += new System.EventHandler(this.categoryTextBox_Leave);
            // 
            // minCostTextBox
            // 
            this.minCostTextBox.Location = new System.Drawing.Point(56, 459);
            this.minCostTextBox.Name = "minCostTextBox";
            this.minCostTextBox.Size = new System.Drawing.Size(262, 22);
            this.minCostTextBox.TabIndex = 12;
            this.minCostTextBox.Text = " ";
            this.minCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minCostTextBox.Enter += new System.EventHandler(this.minCostTextBox_Enter);
            this.minCostTextBox.Leave += new System.EventHandler(this.minCostTextBox_Leave);
            // 
            // query1
            // 
            this.query1.Location = new System.Drawing.Point(56, 52);
            this.query1.Name = "query1";
            this.query1.Size = new System.Drawing.Size(218, 77);
            this.query1.TabIndex = 13;
            this.query1.Text = "Список блюд, для которых продукты категории \'овощи\' предварительно подвергаются \'" +
    "пассеровке\'";
            this.query1.UseVisualStyleBackColor = true;
            this.query1.Click += new System.EventHandler(this.query1_Click);
            // 
            // query2
            // 
            this.query2.Location = new System.Drawing.Point(437, 52);
            this.query2.Name = "query2";
            this.query2.Size = new System.Drawing.Size(218, 77);
            this.query2.TabIndex = 14;
            this.query2.Text = "Названия блюд с указанием калорийности одной порции для каждого из них";
            this.query2.UseVisualStyleBackColor = true;
            this.query2.Click += new System.EventHandler(this.query2_Click);
            // 
            // query3
            // 
            this.query3.Location = new System.Drawing.Point(56, 190);
            this.query3.Name = "query3";
            this.query3.Size = new System.Drawing.Size(218, 77);
            this.query3.TabIndex = 15;
            this.query3.Text = "Блюдо, в которое входит больше всего продуктов категории \'пряность\'";
            this.query3.UseVisualStyleBackColor = true;
            this.query3.Click += new System.EventHandler(this.query3_Click);
            // 
            // query4
            // 
            this.query4.Location = new System.Drawing.Point(437, 190);
            this.query4.Name = "query4";
            this.query4.Size = new System.Drawing.Size(218, 77);
            this.query4.TabIndex = 16;
            this.query4.Text = "Списки входящих для всех блюд категории \'первое блюдо\' продуктов в порядке их доб" +
    "авления";
            this.query4.UseVisualStyleBackColor = true;
            this.query4.Click += new System.EventHandler(this.query4_Click);
            // 
            // paramQuery
            // 
            this.paramQuery.Location = new System.Drawing.Point(393, 336);
            this.paramQuery.Name = "paramQuery";
            this.paramQuery.Size = new System.Drawing.Size(262, 105);
            this.paramQuery.TabIndex = 17;
            this.paramQuery.Text = "Получение данных о блюдах и их продуктах, отфильтрованных по указанной категории " +
    "блюд";
            this.paramQuery.UseVisualStyleBackColor = true;
            this.paramQuery.Click += new System.EventHandler(this.paramQuery_Click);
            // 
            // crossQuery
            // 
            this.crossQuery.Location = new System.Drawing.Point(56, 336);
            this.crossQuery.Name = "crossQuery";
            this.crossQuery.Size = new System.Drawing.Size(262, 105);
            this.crossQuery.TabIndex = 18;
            this.crossQuery.Text = "Общая стоимость каждого блюда, исходя из стоимости ингредиентов, которая превышае" +
    "т заданное минимальное значение";
            this.crossQuery.UseVisualStyleBackColor = true;
            this.crossQuery.Click += new System.EventHandler(this.crossQuery_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 645);
            this.Controls.Add(this.crossQuery);
            this.Controls.Add(this.paramQuery);
            this.Controls.Add(this.query4);
            this.Controls.Add(this.query3);
            this.Controls.Add(this.query2);
            this.Controls.Add(this.query1);
            this.Controls.Add(this.minCostTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.btnToProductForm);
            this.Controls.Add(this.btnToDishForm);
            this.Controls.Add(this.btnToMainForm);
            this.Controls.Add(this.lblReportResult);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportForm";
            this.Text = "Отчёты";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReportResult;
        private System.Windows.Forms.Button btnToMainForm;
        private System.Windows.Forms.Button btnToDishForm;
        private System.Windows.Forms.Button btnToProductForm;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox minCostTextBox;
        private System.Windows.Forms.Button query1;
        private System.Windows.Forms.Button query2;
        private System.Windows.Forms.Button query3;
        private System.Windows.Forms.Button query4;
        private System.Windows.Forms.Button paramQuery;
        private System.Windows.Forms.Button crossQuery;
    }
}
