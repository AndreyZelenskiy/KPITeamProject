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
    public partial class MessHist : Form
    {
        private string mainstr;
        List<MyDict> list;
        private ContactForm cnt;
        public MessHist(ContactForm cnt, List<MyDict> l)
        {
            InitializeComponent();
            this.cnt = cnt;
            list = l;
            MessageHist();
            this.textBox2.Text = mainstr;
        }

        private void MessageHist()
        {
            foreach(MyDict md in list)
            {
                mainstr += string.Format(md.name + ": " + md.text + Environment.NewLine);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
