using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Facade
{
    public class Pupil
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Pupil(int id, string name, string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }
    }
}
