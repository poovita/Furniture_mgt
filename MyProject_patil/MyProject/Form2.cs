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

namespace MyProject
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Daily;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           conn.Open();
            
            SqlCommand cmd = new SqlCommand("INSERT INTO DailyTable(Faculty,Date,Class,Time,Subject,Head)Values('" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Saved...!!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }
    }
}
