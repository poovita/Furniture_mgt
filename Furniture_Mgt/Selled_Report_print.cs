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
            // TODO: This line of code loads data into the 'bill_information.s_bill_auto_generate' table. You can move, or remove it, as needed.
            SqlCommand cmd = new SqlCommand("SELECT top 1 (s_bill_no_auto_inc) FROM s_bill_auto_generate ORDER BY s_bill_no_auto_inc DESC", conn);
            // conn.Open();
            int bill_no = 0;
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

            if (bill_no != 0)
            {
                this.Selled_part_Bill_dataTableAdapter.Fill(this.Parts_information.Selled_part_Bill_data, bill_no);
                this.s_bill_auto_generateTableAdapter.Fill(this.bill_information.s_bill_auto_generate, bill_no);
                this.reportViewer1.RefreshReport();

            }
         
        }
        // TODO: This line of code loads data into the 'Parts_information.Selled_part_Bill_data' table. You can move, or remove it, as needed.
        
        //this.reportViewer1.RefreshReport();


        private void reportViewer1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
