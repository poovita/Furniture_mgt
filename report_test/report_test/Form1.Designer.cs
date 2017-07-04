namespace report_test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.startd = new System.Windows.Forms.DateTimePicker();
            this.endd = new System.Windows.Forms.DateTimePicker();
            this.btnprint = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dailyreportform_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dailyreportform_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "from";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // startd
            // 
            this.startd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startd.Location = new System.Drawing.Point(115, 33);
            this.startd.Name = "startd";
            this.startd.Size = new System.Drawing.Size(200, 20);
            this.startd.TabIndex = 1;
            // 
            // endd
            // 
            this.endd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endd.Location = new System.Drawing.Point(343, 33);
            this.endd.Name = "endd";
            this.endd.Size = new System.Drawing.Size(200, 20);
            this.endd.TabIndex = 2;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(580, 33);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 23);
            this.btnprint.TabIndex = 3;
            this.btnprint.Text = "button1";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dailytest";
            reportDataSource1.Value = this.dailyreportform_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "report_test.dailytestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(104, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(538, 246);
            this.reportViewer1.TabIndex = 4;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dailyreportform_ResultBindingSource
            // 
            this.dailyreportform_ResultBindingSource.DataSource = typeof(report_test.dailyreportform_Result);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 448);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.endd);
            this.Controls.Add(this.startd);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "la";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dailyreportform_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startd;
        private System.Windows.Forms.DateTimePicker endd;
        private System.Windows.Forms.Button btnprint;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dailyreportform_ResultBindingSource;
    }
}

