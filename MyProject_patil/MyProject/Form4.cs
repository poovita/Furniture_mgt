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
            // TODO: This line of code loads data into the 'DataSet1.DailyTable' table. You can move, or remove it, as needed.
            //this.DailyTableTableAdapter.Fill(this.DataSet1.DailyTable, dateTimePicker1.Value.Date.ToShortDateString(), dateTimePicker2.Value.Date.ToShortDateString());

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void dailysubmitprint_Click(object sender, EventArgs e)
        {
            DateTime frm = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            DateTime to_date = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            this.DailyTableTableAdapter.Fill(this.DataSet1.DailyTable, frm, to_date);
            this.reportViewer1.RefreshReport();
          

        }
    }
}