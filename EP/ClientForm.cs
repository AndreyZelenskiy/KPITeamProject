﻿using System;
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
        private CodeParser parser;
        public List<User> users = new List<User>();
        public List<Task> tasks = new List<Task>();
        int taskIndex = 0;
        public DataBase.DataBaseClient client;     
        private AuthorizationsForm _f1;
        public ClientForm(AuthorizationsForm f1)
        {
            InitializeComponent();
            client = new DataBase.DataBaseClient();
            parser = new CodeParser();
            _f1 = f1;
            
        }
        public bool Check(int id) // Проверка на айдишники пользователей
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
        private void CreateMethod(string name)
        {
            textBox4.Text = "namespace Task{" + Environment.NewLine +  "    class User{" + Environment.NewLine + "      public static int " +name + "(){" + Environment.NewLine + "      }" + Environment.NewLine + "    }" + Environment.NewLine+"}";
        }
        public void ContactListRefresher() // Обновление списка контактов
        {
            ContactListBox.Items.Clear(); // Удаление поэлементно работает неверно, приходиться делать так
            foreach (User user in users)
            {
                ContactListBox.Items.Add(user.login);
            }
        }

        

        private void GetList() // Получение списка айдишников друзей и закидывание на в список
        {
            int[] list = client.GetUserFriends(_f1.tmpUserId);
            foreach (int element in list)
            {
                string[] data = client.GetUser(element);
                users.Add(new User(data[0], data[1], data[2], data[3], element));
                List<MyDict> newlist = new List<MyDict>();
                newlist.Add(new MyDict(data[0], "Created"));
                mainUser.list.Add(newlist); 
            }
            ContactListRefresher();
        }

        private void MainUserCreation() // Получение данных пользователя
        {
            string[] userData = client.GetUser(_f1.tmpUserId);
            mainUser = new User(userData[0], userData[1], userData[2], userData[3], _f1.tmpUserId);
        }

        private void TaskLoader()
        {          
            Dictionary<int, string[]> dict = client.TaskList();
            if(dict != null)
            {
                foreach(KeyValuePair<int, string[]> pair in dict)
                {
                    tasks.Add(new Task(pair.Key, pair.Value[0], pair.Value[1]));
                }
            }
            foreach (Task t in tasks)
            {
                TaskBox.Items.Add(t.name);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            MainUserCreation();
            GetList();
            TaskLoader();
        }

        private void ContactBox_SelectedIndexChanged(object sender, EventArgs e) // тут все ясно
        {         
            int index  = ContactListBox.SelectedIndex;
            ContactForm Contact = new ContactForm(this, users[index], mainUser.ListReturner(users[index].firstname));
            Contact.Show();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) // тут тоже все ясно
        {
            Application.Exit();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ContactBtn_Click(object sender, EventArgs e) // Добавление нового друга в список
        {
            if (textBox1.Text != "")
            {
                string[] newUserStr = client.GetUserByLogin(textBox1.Text);
                if (newUserStr == null)
                    MessageBox.Show("Try again, please");
                else
                {
                    int id = Convert.ToInt32(newUserStr[4]);
                    if (!Check(id))
                    {
                        users.Add(new User(newUserStr[0], newUserStr[1], newUserStr[2], newUserStr[3], id));
                        client.AddFriend(mainUser.Id, id);
                        if (mainUser.Check(newUserStr[0]) == false)
                        {
                            List<MyDict> list = new List<MyDict>();
                            list.Add(new MyDict(newUserStr[0], "Created"));
                            mainUser.list.Add(list);
                        }
                    }
                }
            }
            ContactListRefresher();
        }

        /*private void button2_Click(object sender, EventArgs e) // Отправка ответа на сервер для проверки
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
        }*/

        private void button3_Click(object sender, EventArgs e) // вызов нового окна (если не ясно)
        {
            TaskAdd taskAdd = new TaskAdd(this);
            taskAdd.Show();
        }
        
        public void TaskRefresher() //та же проблема, что с френдлистом, но работает
        {
            TaskBox.Items.Clear();
            foreach (Task t in tasks)
            {
                TaskBox.Items.Add(t.name);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //информация мейн юзера
        {
            MainUserForm userForm = new MainUserForm(this, mainUser);
            userForm.Show();
        }

        private void TaskBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskIndex = TaskBox.SelectedIndex;
            textBox2.Text = tasks[taskIndex].text;
            CreateMethod(tasks[taskIndex].name);
        }

        private void button1_Click(object sender, EventArgs e)//Refresher программы
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] result = new string[100];
            if (textBox4.Text != "")
            {
                result = client.AnswerCheck(taskIndex, textBox4.Text);
            }
            foreach(string str in result)
            {
                MessageBox.Show(str);
            }
           
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }
    }
}
