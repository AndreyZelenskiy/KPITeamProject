using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP
{
    public class User
    {
        public string firstname, secondname, login, language;
        public int Id;
        public User(string firstname, string secondname, string login, string language, int id)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.login = login;
            this.language = language;
            this.Id = id;
        }
    }
}
