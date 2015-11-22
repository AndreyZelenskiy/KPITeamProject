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
    public partial class RegForm : Form
    {
        DataBase.DataBaseClient client;
        public RegForm()
        {
            InitializeComponent();
            client = new DataBase.DataBaseClient();
        }
        private AuthorizationsForm _f1;
        public RegForm(AuthorizationsForm f1)
        {
            InitializeComponent();
            client = new DataBase.DataBaseClient();
            _f1 = f1;
        }
        private void RegForm_Load(object sender, EventArgs e)
        {
            FstLabel.Font = new Font("Eras Bold ITC", FstLabel.Font.Size);
            SndLabel.Font = new Font("Eras Bold ITC", SndLabel.Font.Size);
            LoginLabel.Font = new Font("Eras Bold ITC", LoginLabel.Font.Size);
            PassLabel.Font = new Font("Eras Bold ITC", PassLabel.Font.Size);
            LangLabel.Font = new Font("Eras Bold ITC", LangLabel.Font.Size);
            ConfPassLabel.Font = new Font("Eras Bold ITC", ConfPassLabel.Font.Size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _f1.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //DataBase.DataBaseClient client = new DataBase.DataBaseClient();
            string username = LoginBox.Text;
            string password = PassBox.Text;
            int tmpUserId = client.Registration(username, password, FstNmBox.Text, SndNmBox.Text, comboBox1.Text);
            switch (tmpUserId)
            {
                case -10:
                    LoginBox.Text = "";
                    MessageBox.Show("We have user with this login");
                    break;
                case -100:
                    MessageBox.Show("ЛОХ!");
                    break;
                case -20:
                    LoginBox.Text = "";
                    FstNmBox.Text = "";
                    SndNmBox.Text = "";
                    PassBox.Text = "";
                    ConfPassBox.Text = "";
                    comboBox1.Text = "";
                    MessageBox.Show("Failed to add in database");
                    break;
                default:

                    break;
            }
        }
        private void registration_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string username = LoginBox.Text ?? String.Empty;
            string firstName = FstNmBox.Text ?? String.Empty;
            string secondName = SndNmBox.Text ?? String.Empty;
            string password = PassBox.Text ?? String.Empty;
            string confirmPassword = ConfPassBox.Text ?? String.Empty;
            string language = comboBox1.Text;
            string message = "";



            if (username == String.Empty)
            {
                message += "Enter username\n";
                flag = false;
            }

            if(firstName == String.Empty)
            {
                message += "Enter you'r first name\n";
                flag = false;
            }

            if(secondName == String.Empty)
            {
                message += "Enter you'r second name\n";
                flag = false;
            }

            if(password == String.Empty)
            {
                message += "Enter you'r password\n";
                flag = false;
            }
            else
            {
                if( confirmPassword == String.Empty)
                {
                    message += "Enter confirm password\n";
                    flag = false;
                }
                else
                {
                    if(password != confirmPassword)
                    {
                        message += "Confirm password will failed\n";
                        flag = false;
                    }
                }
            }

            if(flag == true)
            {
                DataBase.DataBaseClient client = new DataBase.DataBaseClient();
                try
                {
                    int tmpId = client.Registration(username, password, firstName, secondName, language);
                    switch (tmpId)
                    {
                        case (-10):
                            {
                                MessageBox.Show("Пользователь с таким именем уже существует");
                                break;
                            }
                        case (-20):
                            {
                                MessageBox.Show("Ошибка базы данных, регистрация не была оконченна");
                                break;
                            }
                    }
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void RegForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _f1.Show();
        }
    }
}
