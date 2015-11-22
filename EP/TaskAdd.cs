using System;
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
    public partial class TaskAdd : Form
    {
        ClientForm _f;
        public TaskAdd(ClientForm f)
        {
            InitializeComponent();
            _f = f;
        }
        public bool TaskReturn()
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                _f.tasks.Add(new Task(_f.tasks.Count, textBox1.Text, textBox3.Text));
                System.IO.File.AppendAllText(@"d:\text.txt",Environment.NewLine + _f.tasks.Count + "#" + textBox1.Text + "#" + textBox3.Text);
                return true;
            }
            else
            {
                MessageBox.Show("Enter the fields!");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TaskReturn())
            {
                _f.TaskRefresher();
                this.Close();
            }
        }
    }
}
