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
            this.btnDishCount = new System.Windows.Forms.Button();
            this.lblReportResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDishCount
            // 
            this.btnDishCount.Location = new System.Drawing.Point(50, 30);
            this.btnDishCount.Name = "btnDishCount";
            this.btnDishCount.Size = new System.Drawing.Size(150, 30);
            this.btnDishCount.TabIndex = 0;
            this.btnDishCount.Text = "Количество блюд";
            this.btnDishCount.UseVisualStyleBackColor = true;
            this.btnDishCount.Click += new System.EventHandler(this.btnDishCount_Click);
            // 
            // lblReportResult
            // 
            this.lblReportResult.AutoSize = true;
            this.lblReportResult.Location = new System.Drawing.Point(50, 80);
            this.lblReportResult.Name = "lblReportResult";
            this.lblReportResult.Size = new System.Drawing.Size(0, 13);
            this.lblReportResult.TabIndex = 1;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblReportResult);
            this.Controls.Add(this.btnDishCount);
            this.Name = "ReportForm";
            this.Text = "Отчёты";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnDishCount;
        private System.Windows.Forms.Label lblReportResult;
    }
}
