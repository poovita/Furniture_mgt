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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Furniture_database;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            display_cust();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display_cust();
        }
        //display
        public void display_cust()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from customer_details", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!UserNameCheck())
            {
             //   conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO customer_details Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Saved...!!");
                display_cust();
                ClearData(); 
            }
        }
        //delete cust
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete customer_details where cust_name='" + textBox1.Text + "'", conn);                              
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display_cust();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        //update button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update customer_details set cust_name='" + textBox1.Text + "',cust_addr='" + textBox2.Text + "',cust_mob='" + textBox3.Text + "' where cust_name='" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                display_cust();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            display_cust();
        }
        public void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        public bool UserNameCheck()
        {
            
           
            SqlCommand cmd = new SqlCommand("Select count(*) from customer_details where cust_name=@alias", conn);
            cmd.Parameters.AddWithValue("@alias", this.textBox1.Text);
            conn.Open();
            //  SqlDataReader dr1 = cmd.ExecuteReader();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {
                MessageBox.Show("Alias " + textBox1.Text + " Already exist");
                conn.Close();
                return true;
                
            }
            else
            {
                return false;
              
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;


        }
    }
}
