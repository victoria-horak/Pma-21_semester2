using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                //Programmer programmer = new Programmer();
                IProgrammer programmer = new ProgrammerProxy(new Programmer());
                IEnumerable<Projects> projects = programmer.GetProjects();
                foreach (Projects project in projects)
                {
                    string status = programmer.WorkStatus().First(s => s.Key == project.Status).Value;
                    Console.WriteLine(project.Name + ' ' + status);
                }
            }


        }
    }
}
