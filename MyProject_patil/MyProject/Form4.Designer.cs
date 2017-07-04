namespace MyProject
{
    partial class Form4
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dailysubmitprint = new System.Windows.Forms.Button();
            this.DailyTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new MyProject.DataSet1();
            this.DailyTableTableAdapter = new MyProject.DataSet1TableAdapters.DailyTableTableAdapter();
            this.dailyreportform_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DailyTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyreportform_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(83, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(223, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(83, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // reportViewer1
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.DailyTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyProject.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(49, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dailysubmitprint
            // 
            this.dailysubmitprint.Location = new System.Drawing.Point(370, 11);
            this.dailysubmitprint.Name = "dailysubmitprint";
            this.dailysubmitprint.Size = new System.Drawing.Size(75, 23);
            this.dailysubmitprint.TabIndex = 8;
            this.dailysubmitprint.Text = "Submit";
            this.dailysubmitprint.UseVisualStyleBackColor = true;
            this.dailysubmitprint.Click += new System.EventHandler(this.dailysubmitprint_Click);
            // 
            // DailyTableBindingSource
            // 
            this.DailyTableBindingSource.DataMember = "DailyTable";
            this.DailyTableBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DailyTableTableAdapter
            // 
            this.DailyTableTableAdapter.ClearBeforeFill = true;
            // 
            // dailyreportform_ResultBindingSource
            // 
            this.dailyreportform_ResultBindingSource.DataSource = typeof(MyProject.dailyreportform_Result);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 348);
            this.Controls.Add(this.dailysubmitprint);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DailyTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyreportform_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dailyreportform_ResultBindingSource;
        private System.Windows.Forms.Button dailysubmitprint;
        private System.Windows.Forms.BindingSource DailyTableBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DailyTableTableAdapter DailyTableTableAdapter;
    }
}