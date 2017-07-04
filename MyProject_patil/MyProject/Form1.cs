using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Form1 : Form
    {
        private object textBoxUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True");
            String query = "select * from LoginTable where UserName='" + textBox1.Text.Trim() + "'and Password='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn); 
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count == 1)
            {
                new Form2().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("check your Username and password");
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QI4306H\SQLEXPRESS;Initial Catalog=Login1;Integrated Security=True");
            String query = "select * from Login1Table where UserName='" + textBox1.Text.Trim() + "'and Password='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count == 1)
            {
                new Form3().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("check your Username and password");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
    }

