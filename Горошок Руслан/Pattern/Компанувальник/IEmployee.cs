using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    interface IEmployee
    {
        string Name { get; set; }
        double Salary { get; set; }
        void display(int indent);
    }
}
