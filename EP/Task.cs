using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP
{
    public class Task
    {
        public int id;
        public string name, text;
        public Task(int id, string name, string text)
        {
            this.id = id;
            this.name = name;
            this.text = text;
        }
    }
}
