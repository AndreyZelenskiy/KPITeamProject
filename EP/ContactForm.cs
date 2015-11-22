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
    public partial class ContactForm : Form
    {
        public List<MyDict> list;
        User user;       
        private ClientForm _f1;
        public ContactForm(ClientForm f1, User user, List<MyDict> l)
        {
            InitializeComponent();
            _f1 = f1;
            list = l;
            this.user = user;
            LastNameInfoBox.Text = user.secondname;
            FstNameInfoBox.Text = user.firstname;
            LoginInfoBox.Text = user.login;
            ProgLangInfoBox.Text = user.language;
            textBox1.Text = Message();

        }

        private string Message()
        {
            string message = _f1.client.GetMessage(_f1.mainUser.Id, this.user.Id);
            if(message != null)
            {
                list.Add(new MyDict(this.user.firstname, message));
            }
            return message;
        }

        private void RemovingBtn_Click(object sender, EventArgs e) // удаление инфы о друге)
        {
            _f1.client.DeleteFriend(_f1.mainUser.Id, user.Id);
            _f1.users.Remove(user);
            _f1.ContactListRefresher();
            this.Close();
        }

        private void SendMsgBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Text != "" )
            {
                _f1.client.SendMessage(_f1.mainUser.Id, this.user.Id, MessageBox.Text);
               list.Add(new MyDict(_f1.mainUser.firstname, MessageBox.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessHist messhist = new MessHist(this, _f1.mainUser.ListReturner(user.firstname));
            messhist.Show();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
        }
    }
}
