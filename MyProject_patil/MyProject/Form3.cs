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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO AdminTable(Class,Faculty,Time,Subjects)Values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Saved...!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
