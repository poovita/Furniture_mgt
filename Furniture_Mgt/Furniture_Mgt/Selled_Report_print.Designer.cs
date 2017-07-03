namespace Furniture_Mgt
{
    partial class Selled_Report_print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selled_Report_print));
            this.Selled_part_Bill_dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.furniture_databaseDataSet = new Furniture_Mgt.Furniture_databaseDataSet();
            this.selledpartBilldataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selled_part_Bill_dataTableAdapter = new Furniture_Mgt.Furniture_databaseDataSetTableAdapters.Selled_part_Bill_dataTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Selled_part_Bill_dataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.furniture_databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selledpartBilldataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Selled_part_Bill_dataBindingSource
            // 
            this.Selled_part_Bill_dataBindingSource.DataMember = "Selled_part_Bill_data";
            this.Selled_part_Bill_dataBindingSource.DataSource = this.furniture_databaseDataSet;
            // 
            // furniture_databaseDataSet
            // 
            this.furniture_databaseDataSet.DataSetName = "Furniture_databaseDataSet";
            this.furniture_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // selledpartBilldataBindingSource
            // 
            this.selledpartBilldataBindingSource.DataMember = "Selled_part_Bill_data";
            this.selledpartBilldataBindingSource.DataSource = this.furniture_databaseDataSet;
            this.selledpartBilldataBindingSource.CurrentChanged += new System.EventHandler(this.selledpartBilldataBindingSource_CurrentChanged);
            // 
            // selled_part_Bill_dataTableAdapter
            // 
            this.selled_part_Bill_dataTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Selled_part_Bill_dataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Furniture_Mgt.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(690, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // Selled_Report_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(714, 400);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Selled_Report_print";
            this.Text = "Selled_Report_print";
            this.Load += new System.EventHandler(this.Selled_Report_print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Selled_part_Bill_dataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.furniture_databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selledpartBilldataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Furniture_databaseDataSet furniture_databaseDataSet;
        private System.Windows.Forms.BindingSource selledpartBilldataBindingSource;
        private Furniture_databaseDataSetTableAdapters.Selled_part_Bill_dataTableAdapter selled_part_Bill_dataTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Selled_part_Bill_dataBindingSource;
    }
}