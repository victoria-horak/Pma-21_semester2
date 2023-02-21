using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Programmer :IProgrammer
    {
        public IDictionary<int, string> WorkStatus()
        {
            Dictionary<int, string> status = new Dictionary<int, string>
            {
                { 1, "design" },
                { 2, "working on" },
                { 3, "testing" },
                { 4, "done" }
            };

            Thread.Sleep(2000);
            return status;

        }
        public IEnumerable<Projects> GetProjects()
        {
            Random rnd = new Random();
            List<Projects> projects = new List<Projects>
            {
                new Projects() { Name = "Weather app", Status = rnd.Next(1, 5) },
                new Projects() { Name = "To do list", Status = rnd.Next(1, 5) },
                new Projects() { Name = "Portfolio", Status = rnd.Next(1, 5)}
            };
            return projects;


        }
    }
}
