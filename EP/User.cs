using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP
{
    public class User
    {
        public List<List<MyDict>> list;
        public string firstname, secondname, login, language;
        public int Id;
        public User(string firstname, string secondname, string login, string language, int id)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.login = login;
            this.language = language;
            this.Id = id;
            list = new List<List<MyDict>>();
        }

        public bool Check(string name)
        {
            foreach(List<MyDict> l in list)
            {
                if (l[0].name == name)
                    return true;
            }
            return false;
        }
        public List<MyDict> ListReturner(string name)
        {
            foreach (List<MyDict> l in list)
            {
                if (l[0].name == name)
                    return l;
            }
            return null;
        }
    }
}
