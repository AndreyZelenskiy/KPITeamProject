﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EP
{
    public partial class MainUserForm : Form
    {
        private ClientForm _f1;
        public MainUserForm(ClientForm f1, User user)
        {
            InitializeComponent();
            _f1 = f1;
            textBox1.Text = user.login;
            textBox2.Text = user.firstname;
            textBox3.Text = user.secondname;
            textBox4.Text = user.language;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
