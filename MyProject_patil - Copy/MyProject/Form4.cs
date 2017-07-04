using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void dailysubmitprint_Click(object sender, EventArgs e)
        {
            //try
            //{
            try
            {
                using (DailyEntities1 db = new DailyEntities1())
                {
                    dailyreportform_ResultBindingSource.DataSource = db.dailyreportform(dateTimePicker1.Value, dateTimePicker2.Value).ToList();
                    ReportParameter[] rp = new ReportParameter[]
                   {
                    new ReportParameter("dateStart",dateTimePicker1.Value.Date.ToShortDateString()),
                    new ReportParameter("dateEnd", dateTimePicker2.Value.Date.ToShortDateString())
                   };
                    this.reportViewer1.LocalReport.DataSources.Clear();                   
                      this.reportViewer1.LocalReport.SetParameters(rp);
                      this.reportViewer1.RefreshReport();


                }
            }
            catch (Exception)
            {

                throw;
            }
          //  }
            //catch (Exception ex)
            //{
            //    Console.log(ex));
            //}

        }
    }
}