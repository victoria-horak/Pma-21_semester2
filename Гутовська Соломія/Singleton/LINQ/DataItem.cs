using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQwithJSON
{
    internal class DataItem
    {
        public string objectId { get; set; }
        public string effectiveFrom { get; set; }
        public string effectiveTo { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
