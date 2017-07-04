using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace report_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

          //  this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (DailytestEntities db = new DailytestEntities())
            {
               
                dailyreportform_ResultBindingSource.DataSource = db.dailyreportform(startd.Value, endd.Value).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] reparam = new Microsoft.Reporting.WinForms.ReportParameter[] {
                    new Microsoft.Reporting.WinForms.ReportParameter("dateStart",startd.Value.Date.ToShortDateString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("dateEnd", endd.Value.Date.ToShortDateString())

                };

                this.reportViewer1.LocalReport.SetParameters(reparam);
                this.reportViewer1.RefreshReport();


            }
        }
    }
}
