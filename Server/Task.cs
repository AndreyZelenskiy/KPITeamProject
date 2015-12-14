using System;
using System.Security.Cryptography;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Server
{
    public class Task
    {
        private int _id;
        private string _name;
        private int _answer;
        private string _methodName;

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Answer
        {
            get { return _answer; }
        }

        public string MethodName
        {
            get { return _methodName; }
        }

        public Task(string name)
        {
            DataBase db = new DataBase();
            DataTable queryResult = db.GetQuery(string.Format("select * from tasklist where task_name = '{0}'", name));

            if (queryResult.Rows.Count != 0)
            {
                _id = (int)queryResult.Rows[0]["id"];
                _name = (string)queryResult.Rows[0]["task_name"];
                _answer = (int)queryResult.Rows[0]["task_answer"];
                _methodName = _name;
            }
            else
                throw new System.Exception("Can't find task");
        }

        public Task(int id)
        {
            DataBase db = new DataBase();
            DataTable queryResult = db.GetQuery(string.Format("select * from tasklist where id = '{0}'", id+1));

            if (queryResult.Rows.Count != 0)
            {
                _id = (int)queryResult.Rows[0]["id"];
                _name = (string)queryResult.Rows[0]["task_name"];
                _answer = (int)queryResult.Rows[0]["task_answer"];
                _methodName = _name;
            }
            else
                throw new System.Exception("Can't find task");
        }
    }
}