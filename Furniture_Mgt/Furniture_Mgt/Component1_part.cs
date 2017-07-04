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
    public partial class Component1_part : Form
    {
      
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Furniture_database;Integrated Security=True");
        public Component1_part()
        {
            InitializeComponent();
            display_comp();
            ClearData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!component_check())
            {
                //   conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO component_details Values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Saved...!!");
                display_comp();
                ClearData();
            }
        }
        public bool component_check()
        {
            // string constring = "Data Source=LFC;Initial Catalog=contactmgmt;Integrated Security=True";
            // SqlConnection con = new SqlConnection(constring);

            SqlCommand cmd = new SqlCommand("Select count(*) from component_details where part_name=@alias", conn);
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
        public void display_comp()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from component_details", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display_comp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update component_details set part_name='" + textBox1.Text + "',price='" + textBox2.Text + "',vat='" + comboBox1.Text + "',qty_componet='" + textBox4.Text + "' where part_name='" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                display_comp();
           ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete component_details where part_name='" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display_comp();
             ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        public void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Component1_part_Load(object sender, EventArgs e)
        {

        }
    }
}
