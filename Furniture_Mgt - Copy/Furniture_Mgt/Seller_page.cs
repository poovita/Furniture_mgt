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
    public partial class Seller_page : Form
    {
       // SqlDataAdapter da; 
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Furniture_database;Integrated Security=True");
        private object reportViewer1;
        private object selled_parts;

        public object Selled_part_Bill_dataTableAdapter { get; private set; }

        public Seller_page()
        {
            InitializeComponent();
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Seller_page_Load(object sender, EventArgs e)
        {

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;


            // TODO: This line of code loads data into the 'furniture_databasepart_search.component_details' table. You can move, or remove it, as needed.
            //  this.component_detailsTableAdapter.Fill(this.furniture_databasepart_search.component_details);
            //load customer names
            AutoSearch_customer();
            AutoSearch_product();
            Get_bill_number();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Go_home();
        }
        public void Go_home()
        {
            new Form1().Show();
            this.Hide();

        }

        //ge bill number
        public void Get_bill_number()
        {

            SqlCommand cmd = new SqlCommand("SELECT top 1 (s_bill_no_auto_inc) FROM s_bill_auto_generate ORDER BY s_bill_no_auto_inc DESC", conn);
           // conn.Open();
           // cmd.ExecuteNonQuery();
            try
            {
                conn.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string bill_no=read["s_bill_no_auto_inc"].ToString();
                        textBox1.Text = (Int32.Parse(bill_no) + 1).ToString();
                      
                    }
                }
            }
            finally
            {
                conn.Close();
            }



        }
        //Total item count
        public void Get_Total_item_count_net_qty()
        {

            SqlCommand cmd = new SqlCommand("SELECT sum(s_net) as netamt,COUNT(s_bill_no)as totalitem,SUM(s_qty)as total_qty FROM Selled_part_Bill_data where s_bill_no='" + textBox1.Text+"' ", conn);
            // conn.Open();
            // cmd.ExecuteNonQuery();
            try
            {
                conn.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string totalitem = read["totalitem"].ToString();
                        textBox8.Text = (Int32.Parse(totalitem)).ToString();
                        string netamt = read["netamt"].ToString();
                        textBox12.Text = (Int32.Parse(netamt)).ToString();
                        string total_qty = read["total_qty"].ToString();
                        textBox9.Text = (Int32.Parse(total_qty)).ToString();


                    }
                }
            }
            finally
            {
                conn.Close();
            }



        }
        //Total item quantity
        //public void Get_Total_item_qty()
        //{

        //    SqlCommand cmd = new SqlCommand("SELECT sum(s_qty) FROM Selled_part_Bill_data where s_bill_no='" + textBox1.Text + "' ", conn);
        //    // conn.Open();
        //    // cmd.ExecuteNonQuery();
        //    try
        //    {
        //        conn.Open();

        //        using (SqlDataReader read = cmd.ExecuteReader())
        //        {
        //            while (read.Read())
        //            {
        //                string bill_no = read[""].ToString();
        //                textBox9.Text = (Int32.Parse(bill_no)).ToString();

        //            }
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }



        //}

        //Auto fill data custmoer name
        public void AutoSearch_customer()

        {
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            SqlDataAdapter da;
            da = new SqlDataAdapter("select cust_name from customer_details order by cust_name asc", conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)

            {

                for (int i = 0; i < dt.Rows.Count; i++)

                {

                    coll.Add(dt.Rows[i]["cust_name"].ToString());

                }

            }
            else

            {

                MessageBox.Show("Name not found");

            }

            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;

            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox2.AutoCompleteCustomSource = coll;

        }
        public void AutoSearch_product()

        {
        //   // conn.Open();
            //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        //  //  AutoCompleteStringCollection coll1= new AutoCompleteStringCollection();

            SqlDataAdapter da;
            string sqlquery = "select part_name from component_details order by part_name asc";                     

            da = new SqlDataAdapter(sqlquery, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)

            {

                for (int i = 0; i < dt.Rows.Count; i++)

                {

                    comboBox1.Items.Add(dt.Rows[i]["part_name"].ToString());

                }

            }
            else

            {

                MessageBox.Show("Name not found");

            }

            //comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;

            //comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //comboBox1.AutoCompleteCustomSource = coll;

            //textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;

            //textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //private void textBox13_TextChanged(object sender, EventArgs e)
        //{


            
        //}

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select price from component_details where part_name ='" + comboBox1.Text + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string price = dr["price"].ToString();
                textBox4.Text = price;
            }
            conn.Close();
        }

    
      

        private void button1_Click(object sender, EventArgs e)
        {
            if (!list_item_check())
            {
                //conn.Open();
             //   calculate_itm_Net_amount();
                SqlCommand cmd = new SqlCommand("INSERT INTO Selled_part_Bill_data Values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                // MessageBox.Show("Successfully Saved...!!");
                display_selled_ietems();
                //display_comp();
                Get_Total_item_count_net_qty();
               // Get_Total_item_qty();
                ClearData(); 
            }
        }
        //calculating total and net
        //public void calculate_itm_Net_amount()
        //{

        //    //conn.Open();

           

            
        //}


        /// <summary>


        /// </summary>
        //Display list of items selled
        public void display_selled_ietems()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("select s_part_name,s_qty,s_price,s_amt,s_discount,s_net from Selled_part_Bill_data where s_bill_no='"+textBox1.Text+"'", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SellerdataGridView1.DataSource = dt;
            conn.Close();
            LoadSerial();
        }
        //sr no 
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in SellerdataGridView1.Rows)
            {
                row.Cells["SNo"].Value = i; i++;
            }
        }
    



    //clear form
    public void ClearData()
        {
            // textBox1.Text="";
            //textBox2.Text = "";
            //dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Update list part item
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Selled_part_Bill_data set s_qty='" + textBox3.Text + "',s_price='" + textBox4.Text + "',s_amt='" + textBox5.Text + "',s_discount='" + textBox6.Text + "',s_net='" + textBox7.Text + "' where s_part_name='" + comboBox1.Text + "' and s_bill_no='"+textBox1.Text+"'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                display_selled_ietems();
                Get_Total_item_count_net_qty();
                //Get_Total_item_qty();
                // display_comp();s_qty,s_price,s_amt,s_discount,s_net
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
        //check duplicate product
        public bool list_item_check()
        {


            SqlCommand cmd = new SqlCommand("Select count(*) from Selled_part_Bill_data where s_part_name=@alias and s_bill_no='"+textBox1.Text+"' ", conn);
            cmd.Parameters.AddWithValue("@alias", this.comboBox1.Text);
            conn.Open();
            //  SqlDataReader dr1 = cmd.ExecuteReader();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {
                MessageBox.Show("Alias " + comboBox1.Text + " Already exist");
                conn.Close();
                return true;

            }
            else
            {
                return false;

            }
        }
        //Delete part from list
        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Selled_part_Bill_data where s_part_name='" + comboBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                // display_comp();
                ClearData();
                // Get_Total_item_qty();
                Get_Total_item_count_net_qty();
                display_selled_ietems();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }



        private void textBox3_tab(object sender, EventArgs e)
        {
            if (textBox3.Text!=""&& textBox4.Text != "")
            {
                int qty = Int32.Parse(textBox3.Text);
                int price = Int32.Parse(textBox4.Text);

                int amt = qty * price;
                textBox5.Text = amt.ToString(); 
            }
        }

        private void textBox6_tab(object sender, EventArgs e)
        {
            if (textBox5.Text!=""&& textBox6.Text!="")
            {
                int amt = Int32.Parse(textBox5.Text);
                int discount = Int32.Parse(textBox6.Text);
                int net = amt - discount;
                textBox7.Text = net.ToString(); 
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox12.Text != "")
            {
                int total_amt = Int32.Parse(textBox12.Text);
                int paid = Int32.Parse(textBox10.Text);
                int remaing = total_amt - paid;
                textBox11.Text = remaing.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "" && textBox10.Text != ""&& textBox1.Text != "")
            {
                  conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO s_bill_auto_generate Values('" + textBox2.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox12.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + dateTimePicker1.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Saved...!!");
                //display_cust();
                ClearData();
               // Go_home();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Selled_Report_print().Show();
            this.Hide();
           
            // 
            //  Selled_Report_print sel= new Selled_Report_print();

        }
    }
}
