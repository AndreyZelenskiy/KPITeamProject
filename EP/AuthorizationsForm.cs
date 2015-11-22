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
    public partial class AuthorizationsForm  : Form
    {
        public int tmpUserId;
        public AuthorizationsForm()
        {
            InitializeComponent();
            
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            DataBase.DataBaseClient client = new DataBase.DataBaseClient();
            client.Open();
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            tmpUserId = client.Authorizate(username, password);
            switch (tmpUserId)
            {
                case -1:
                    {
                        usernameBox.Text = "";
                        passwordBox.Text = "";
                        Bitmap fail = new Bitmap(@"..\..\images\fail1.png");
                        nameCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        passwordCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        nameCheckBox.Image = fail;
                        passwordCheckBox.Image = fail;
                        client.Close();
                        break;
                    }
                case -2:
                    {
                        passwordBox.Text = "";
                        Bitmap suceed = new Bitmap(@"..\..\images\suceed.jpg");
                        Bitmap fail = new Bitmap(@"..\..\images\fail1.png");
                        nameCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        passwordCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        nameCheckBox.Image = suceed;
                        passwordCheckBox.Image = fail;
                        client.Close();
                        break;
                    }
                default:
                    MessageBox.Show("Succed!");
                    ClientForm InClient = new ClientForm(this);
                    this.Hide();
                    InClient.Show();
                    // this.Close();
                    break;
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AuthorizationsForm_Load(object sender, EventArgs e)
        {
            NameLabel.Font = new Font("Eras Bold ITC", NameLabel.Font.Size);
            PassLabel.Font = new Font("Eras Bold ITC", PassLabel.Font.Size);
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            RegForm reg = new RegForm(this);
            this.Hide();
            reg.Show();

        }
        

        private void registrationButton_Click_1(object sender, EventArgs e)
        {
            RegForm reg = new RegForm(this);
            this.Hide();
            reg.Show();
        }
    }
}
