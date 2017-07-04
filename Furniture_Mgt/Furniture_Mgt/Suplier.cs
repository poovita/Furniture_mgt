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

    public partial class Suplier : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Furniture_database;Integrated Security=True");
        public Suplier()
        {
            InitializeComponent();
            display_suppler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!suplierNameCheck())
            {
                //   conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO supplier Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Saved...!!");
                display_suppler();
                ClearData();
            }
        }
        //clear
        public void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        //display
        public void display_suppler()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from supplier", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();
        }


        public bool suplierNameCheck()
        {


            SqlCommand cmd = new SqlCommand("Select count(*) from supplier where sup_name=@alias", conn);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update supplier set sup_name='" + textBox1.Text + "',sup_addr='" + textBox2.Text + "',sup_mob='" + textBox3.Text + "' where sup_name='" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                display_suppler();
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
                SqlCommand cmd = new SqlCommand("delete supplier where sup_name='" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display_suppler();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void Suplier_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}
