using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture_Mgt
{
    public partial class Selled_Report_print : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Furniture_database;Integrated Security=True");
        public Selled_Report_print()
        {
            InitializeComponent();
        }

        private void Selled_Report_print_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;




            // TODO: This line of code loads data into the 'furniture_databaseDataSet.Selled_part_Bill_data' table. You can move, or remove it, as needed.

            //Decimal billno = Int32.Parse(textBox1.Text);

            // TODO: This line of code loads data into the 'sell_part_n.Selled_part_Bill_data' table. You can move, or remove it, as needed.

            //     Seller_page sellepg = new Seller_page();
            //Seller_page sellepg = new Seller_page();

            //MessageBox.Show("billno:" + sellepg.textBox1.Text.ToString());
            //MessageBox.Show("billno:" + sellepg.textBox1.Text);
            //int billno = Int32.Parse(sellepg.textBox1.Text.ToString());

            SqlCommand cmd = new SqlCommand("SELECT top 1 (s_bill_no_auto_inc) FROM s_bill_auto_generate ORDER BY s_bill_no_auto_inc DESC", conn);
            // conn.Open();
            int bill_no=0;
            // cmd.ExecuteNonQuery();
            try
            {
                conn.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        bill_no = Int32.Parse(read["s_bill_no_auto_inc"].ToString());
                       

                    }
                }
            }
            finally
            {
                conn.Close();
            }

            if (bill_no!=0)
            {
                this.selled_part_Bill_dataTableAdapter.Fill(this.furniture_databaseDataSet.Selled_part_Bill_data, bill_no);
                this.reportViewer1.RefreshReport();

            }

           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //int billno = Int32.Parse(textbo);


            //decimal bill_no = 2;
            //this.Selled_part_Bill_dataTableAdapter.Fill(this.selled_part.Selled_part_Bill_data, bill_no);

            //
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

            //Seller_page sellepg = new Seller_page();

            //int billno = Int32.Parse(sellepg.textBox1.Text);
            //Selled_Report_print se = new Selled_Report_print();
            //MessageBox.Show("billno:"+ sellepg.textBox1.Text);
            //// TODO: This line of code loads data into the 'furniture_databaseDataSet.Selled_part_Bill_data' table. You can move, or remove it, as needed.
            //se.selled_part_Bill_dataTableAdapter.Fill(se.furniture_databaseDataSet.Selled_part_Bill_data, );
            //se.reportViewer1.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    int billno = Int32.Parse(textBox1.Text);
        //  //  decimal d = (decimal)billno / 100;
        //    // TODO: This line of code loads data into the 'furniture_databaseDataSet.Selled_part_Bill_data' table. You can move, or remove it, as needed.
        //    this.selled_part_Bill_dataTableAdapter.Fill(this.furniture_databaseDataSet.Selled_part_Bill_data, billno);
        //    this.reportViewer1.RefreshReport();
        }

        private void selledpartBilldataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
