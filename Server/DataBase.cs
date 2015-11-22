using System;
using System.Security.Cryptography;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Server
{

    class DataBase : IDataBase
    {
        private MySqlConnection _connection;

        public DataBase()
        {
            MySqlConnectionStringBuilder _connectionSB = new MySqlConnectionStringBuilder();
            _connectionSB.Server = "localhost";
            _connectionSB.UserID = "server";
            _connectionSB.Password = "1111";
            _connectionSB.Database = "KPITeamProject";

            _connection = new MySqlConnection(_connectionSB.ConnectionString);
            try
            {
                _connection.Open();
                if (!_connection.Ping())
                    Log.Write("DataBase connection is failed", false);
                _connection.Close();
                Log.Write("Ping and open connection was succeed", true);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, false);
            }
        }

        public void SendMessage(int firstid, int secondid, string message)
        {
            DataTable queryResult = GetQuery(string.Format("select * from sendlist where first_id = '{0}' and second_id = '{1}'",
                firstid, secondid));
            if (queryResult == null) { Log.Write("SQL query error", false); throw new Exception("SQL query error"); }
            if(queryResult.Rows.Count > 0)
            {
                GetQuery(string.Format("delete from sendlist where first_id = '{0}' and second_id = '{1}'",
                    firstid, secondid));
            }
            GetQuery(string.Format("insert into sendlist(first_id, second_id, message) values('{0}','{1}','{2}')", 
                firstid, secondid, message));
        }

        public string GetMessage(int firstid, int secondid)
        {
            DataTable queryResult = GetQuery(string.Format("select * from sendlist where first_id = '{0}' and second_id = '{1}'",
                secondid, firstid));
            if (queryResult == null) { Log.Write("SQL query error", false); throw new Exception("SQL query error"); }
            if (queryResult.Rows.Count > 0)
            {
                return (string)queryResult.Rows[0]["message"];
            }
            else return null;

        }

        public bool AnswerCheck(int id, int answer)
        {
            DataTable queryResult = GetQuery(string.Format("select * from tasklist where id = '{0}'", id));
            if (queryResult == null) { Log.Write("SQL query error", false); throw new Exception("SQL query error"); }
            if ((int)queryResult.Rows[0]["task_answer"] == answer)
                return true;
            else return false;

        }

        public string[] GetUser(int idUser)
        {
            string [] result = null;

            DataTable queryResult = GetQuery(String.Format("select * from users where id_user='{0}'", idUser));
            if(queryResult == null) { Log.Write("SQL query error", false); throw new Exception("SQL query error"); }

            if(queryResult.Rows.Count == 0)
                return result;

            result = new string[5];
            DataRow row = queryResult.Rows[0];
            result[0] = (string)row["user_first_name"];
            result[1] = (string)row["user_second_name"];
            result[2] = (string)row["user_login"];
            result[3] = (string)row["user_programming_language"];
            result[4] = Convert.ToString(row["id_user"]);
            return result;
        }
        public string[] GetUserByLogin(string login)
        {
            string[] result = null;

            DataTable queryResult = GetQuery(String.Format("select * from users where user_login='{0}'", login));
            if (queryResult == null) { Log.Write("SQL query error", false); throw new Exception("SQL query error"); }

            if (queryResult.Rows.Count == 0)
                return result;

            result = new string[5];
            DataRow row = queryResult.Rows[0];
            result[0] = (string)row["user_first_name"];
            result[1] = (string)row["user_second_name"];
            result[2] = (string)row["user_login"];
            result[3] = (string)row["user_programming_language"];
            result[4] = Convert.ToString(row["id_user"]);
            return result;
        }

        public Dictionary<int, string[]> TaskList()
        {
            Dictionary<int, string[]> dict;
            DataTable queryResult = GetQuery("select * from tasklist");
            if (queryResult == null) { Log.Write("Failed sql query", false); throw new Exception("Failed sql query"); }
            dict = new Dictionary<int, string[]>();
            for (int i = 0; i < queryResult.Rows.Count; i++)
            {
                string[] str = new string[2];
                str[0] = (string)queryResult.Rows[i]["task_name"];
                str[1] = (string)queryResult.Rows[i]["task_text"];
                dict.Add((int)queryResult.Rows[i]["id"], str);
            }
            return dict;
        }

        public int AddTask(params string [] task)
        {
            string name = task[0];
            DataTable queryResult = GetQuery(string.Format("select * from tasklist where task_name ='{0}'", name));
            if (queryResult == null) { Log.Write("Failed sql query", false); throw new Exception("Failed sql query"); }
            if (queryResult.Rows.Count != 0) return -1;
            else
            {
                GetQuery(string.Format("insert into tasklist(task_name, task_answer, task_text) values ('{0}','{1}','{2}')",
                    name, task[1], task[2]));
            }
            queryResult = GetQuery(string.Format("select * from tasklist where task_name ='{0}'", name));
            if (queryResult == null) { Log.Write("Failed sql query", false); throw new Exception("Failed sql query"); }
            if (queryResult.Rows.Count == 1) return 1;
            else return 0;
        }

        public List<int> GetUserFriends(int idUser)
        {
            DataTable queryResult = GetQuery(String.Format("select * from friends where first_id='{0}'", idUser));
            if(queryResult == null) { Log.Write("Failed sql query", false); throw new Exception("Failed sql query"); }

            List<int> result = new List<int>();
            foreach(DataRow row in queryResult.Rows)
                result.Add((int)row[2]);

            return result;
        }

        private bool CheckUser(int id_user)
        {
            DataTable queryResult = GetQuery(String.Format("select * from users where id_user = '{0}'", id_user));
            if (queryResult.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public void AddFriend(int first_id, int second_id)
        {
            if ((first_id <= 0 || second_id <= 0) || (first_id == second_id))
                throw new Exception("Invalid parametrs");

            if (!CheckUser(first_id) || !CheckUser(second_id))
                throw new Exception("Cant find user in database");

            GetQuery(String.Format(
               "insert into friends(first_id, second_id) values ('{0}', '{1}'), ('{1}', '{0}')", first_id, second_id));
            DataTable queryResult = GetQuery(String.Format("select * from friends where first_id='{0}' and second_id='{1}'", first_id, second_id));
            if (queryResult.Rows.Count == 0)
                throw new Exception("Can't add this friends");
        }

        public void DeleteFriend(int first_id, int second_id)
        {
            if ((first_id <= 0 || second_id <= 0) || (first_id == second_id))
                throw new Exception("Invalid parametrs");

            if (!CheckUser(first_id) || !CheckUser(second_id))
                throw new Exception("Cant find user in database");


            DataTable queryResult = GetQuery(String.Format("select * from friends where first_id = '{0}' and second_id = '{1}'", first_id, second_id));
            if (queryResult.Rows.Count == 0)
                throw new Exception("Can't find this friends in database");

            GetQuery(String.Format(
                "delete from friends where first_id in ('{0}', '{1}') and second_id in ('{0}', '{1}')",
                first_id, second_id));

            queryResult = GetQuery(String.Format("select * from friends where first_id = '{0}' and second_id = '{1}'", first_id, second_id));
            if (queryResult.Rows.Count == 1)
                throw new Exception("Can't remove this friends from database");

        }

        public int Authorizate(string username, string password)
        {
            DataTable queryResult;
            try
            {
                queryResult = GetQuery(String.Format("select * from users where user_login='{0}'", username));
                if (queryResult.Rows.Count == 0)
                    return -1;
                string passwordHash = GetMD5HashCode(password);
                foreach (DataRow row in queryResult.Rows)
                {
                    if (passwordHash == (string)row["user_password"])
                    {
                        Log.Write(username, false);
                        return (int)row["id_user"];
                    }
                }
                return -2;
            }
            catch(Exception ex)
            {
                Log.Write(ex.Message, false);
                return -1;
            }

        }

        public int Registration(string username, string password, string firstname, string secondname, string programmingLanguage)
        {
            try
            {
                DataTable result = GetQuery(String.Format("select * from users where user_login='{0}'", username));
                if (result == null) { Log.Write("SQL query is failed", false); return -100; }

                if (result.Rows.Count == 0)
                {
                    result = GetQuery(String.Format("insert into users(user_login, user_first_name, user_second_name, user_password, user_programming_language) values('{0}', '{1}', '{2}', '{3}', '{4}')",
                        username, firstname, secondname, GetMD5HashCode(password), programmingLanguage));
                    if (result == null) { Log.Write("SQL query is failed", false); return -100; }

                    result = GetQuery(String.Format("select * from users where user_login = '{0}'", username));
                    if (result == null) { Log.Write("SQL query is failed", false); return -100; }

                    if (result.Rows.Count == 1) { return Convert.ToInt32(result.Rows[0]["id_user"]); }
                    else { return -20; }
                } else { return -10; }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return 0;
        }
        private DataTable GetQuery(string query)
        {
            DataTable dt = null;
            try
            {
                _connection.Open();
                MySqlCommand comm = new MySqlCommand(query, _connection);
                MySqlDataReader dr = comm.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
       
                _connection.Close();
            }
            catch(Exception ex)
            {
                Log.Write(ex.Message, false);
            }
            if (dt == null)
              throw new Exception("Invalid sql command");
            return dt;
        }

        private string GetMD5HashCode(string input)
        {
            //Создание хэшируещего объекта
            MD5 md5 = MD5.Create();

            //Конвертирование хэш-значения входящей строки в массив бит
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Создание конструктора строки для преобразования хэш-суммы в строку
            StringBuilder sBuilder = new StringBuilder();

            //Воссоздание строки из массива бит в формате х2
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
