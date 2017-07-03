﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture_Mgt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Component1_part().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Suplier().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Seller_page().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Purchase_page().Show();
            this.Hide();
        }
    }
}
