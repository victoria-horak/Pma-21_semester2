using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable]
    public class Student
    {
        public string Name;
        public Aducation Aducation;

        public override string ToString()
        {
            return $"Name: {Name}, Aducation = {Aducation}";
        }
    }
}
