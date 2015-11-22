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
        
        User user;
        public ContactForm()
        {
            InitializeComponent();
        }
        private ClientForm _f1;
        public ContactForm(ClientForm f1, User user)
        {
            InitializeComponent();
            _f1 = f1;
            this.user = user;
            LastNameInfoBox.Text = user.secondname;
            FstNameInfoBox.Text = user.firstname;
            LoginInfoBox.Text = user.login;
            ProgLangInfoBox.Text = user.language;
            
        }

        private void RemovingBtn_Click(object sender, EventArgs e)
        {
            _f1.client.DeleteFriend(_f1.mainUser.Id, user.Id);
            _f1.users.Remove(user);
            _f1.MyRefresh();
            this.Close();
        }
    }
}
