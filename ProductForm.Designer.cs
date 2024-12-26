namespace cooking
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToReportForm = new System.Windows.Forms.Button();
            this.btnToDishForm = new System.Windows.Forms.Button();
            this.btnToMainForm = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToReportForm
            // 
            this.btnToReportForm.Location = new System.Drawing.Point(60, 456);
            this.btnToReportForm.Name = "btnToReportForm";
            this.btnToReportForm.Size = new System.Drawing.Size(113, 36);
            this.btnToReportForm.TabIndex = 4;
            this.btnToReportForm.Text = "К отчетам";
            this.btnToReportForm.UseVisualStyleBackColor = true;
            this.btnToReportForm.Click += new System.EventHandler(this.btnToReportForm_Click);
            // 
            // btnToDishForm
            // 
            this.btnToDishForm.Location = new System.Drawing.Point(411, 450);
            this.btnToDishForm.Name = "btnToDishForm";
            this.btnToDishForm.Size = new System.Drawing.Size(111, 42);
            this.btnToDishForm.TabIndex = 3;
            this.btnToDishForm.Text = "К блюдам";
            this.btnToDishForm.UseVisualStyleBackColor = true;
            this.btnToDishForm.Click += new System.EventHandler(this.btnToDishForm_Click);
            // 
            // btnToMainForm
            // 
            this.btnToMainForm.Location = new System.Drawing.Point(778, 450);
            this.btnToMainForm.Name = "btnToMainForm";
            this.btnToMainForm.Size = new System.Drawing.Size(112, 45);
            this.btnToMainForm.TabIndex = 2;
            this.btnToMainForm.Text = "На главную";
            this.btnToMainForm.UseVisualStyleBackColor = true;
            this.btnToMainForm.Click += new System.EventHandler(this.btnToMainForm_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 82);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(630, 258);
            this.dgvProducts.TabIndex = 0;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 764);
            this.Controls.Add(this.btnToReportForm);
            this.Controls.Add(this.btnToDishForm);
            this.Controls.Add(this.btnToMainForm);
            this.Controls.Add(this.dgvProducts);
            this.HelpButton = true;
            this.Name = "ProductForm";
            this.Text = "Продукты";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnToMainForm;
        private System.Windows.Forms.Button btnToDishForm;
        private System.Windows.Forms.Button btnToReportForm;
    }
}