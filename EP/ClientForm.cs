using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EP
{
    
    public partial class ClientForm : Form
    {
        public User mainUser;
        public List<User> users = new List<User>();
        public List<Task> tasks = new List<Task>();
        int taskIndex = 0;
        public DataBase.DataBaseClient client;
        public ClientForm()
        {
            InitializeComponent();
        }
        private AuthorizationsForm _f1;
        public ClientForm(AuthorizationsForm f1)
        {
            InitializeComponent();
            client = new DataBase.DataBaseClient();
            _f1 = f1;
            
        }
        public bool Check(int id)
        {
            if (_f1.tmpUserId == id)
                return true;
            foreach(User user in users)
            {
                if(user.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public void MyRefresh()
        {
            ContactListBox.Items.Clear();
            foreach (User user in users)
            {
                ContactListBox.Items.Add(user.login);
            }
        }
       
        private void GetList()
        {
            int[] l = client.GetUserFriends(_f1.tmpUserId);
            foreach (int a in l)
            {
                string[] data = client.GetUser(a);
                users.Add(new User(data[0], data[1], data[2], data[3], a));
            }
            MyRefresh();
        }

        private void MainUserCreation()
        {
            string[] userData = client.GetUser(_f1.tmpUserId);
            mainUser = new User(userData[0], userData[1], userData[2], userData[3], _f1.tmpUserId);
        }

        private void TaskLoader()
        {
            string[] task = File.ReadAllLines(@"d:\text.txt");
            foreach (string str in task)
            {
                string[] tmp = str.Split('#');
                tasks.Add(new Task(Convert.ToInt32(tmp[0]), tmp[1], tmp[2]));
            }
            foreach (Task t in tasks)
            {
                TaskBox.Items.Add(t.name);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            GetList();
            MainUserCreation();
            TaskLoader();
        }

        private void ContactBox_SelectedIndexChanged(object sender, EventArgs e)
        {         
            int index  = ContactListBox.SelectedIndex;
            ContactForm Contact = new ContactForm(this, users[index]);
            Contact.Show();
    }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ContactBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string[] newUserStr = client.GetUserByLogin(textBox1.Text);
                if (newUserStr == null)
                    MessageBox.Show("Try again, please");
                else
                {
                    if (!Check(Convert.ToInt32(newUserStr[4])))
                    {
                        users.Add(new User(newUserStr[0], newUserStr[1], newUserStr[2], newUserStr[3], Convert.ToInt32(newUserStr[4])));
                        client.AddFriend(mainUser.Id, Convert.ToInt32(newUserStr[4]));
                    }
                }
            }
            MyRefresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (textBox3.Text != "")
                {
                    if (client.AnswerCheck(tasks[taskIndex].id, Convert.ToInt32(textBox3.Text)))
                    {
                        MessageBox.Show("Correct!");
                    }
                    else MessageBox.Show("Try again");
                }
                textBox3.Clear();
            }
            catch
            {
                MessageBox.Show("Please, enter a digit!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaskAdd taskAdd = new TaskAdd(this);
            taskAdd.Show();
        }
        
        public void TaskRefresher()
        {
            TaskBox.Items.Clear();
            foreach (Task t in tasks)
            {
                TaskBox.Items.Add(t.name);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainUserForm userForm = new MainUserForm(this, mainUser);
            userForm.Show();
        }

        private void TaskBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskIndex = TaskBox.SelectedIndex;
            textBox2.Text = tasks[taskIndex].text;
        }
    }
}
