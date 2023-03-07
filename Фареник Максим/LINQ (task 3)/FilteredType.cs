using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class FilteredType
    {
        public string identificatorId { get; set; }
        public string objectId { get; set; }
        public DateTime effectiveFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        public string type { get; set; }
        public override string ToString()
        {
            return $"ID: {identificatorId}\nObject ID: {objectId}\nEffective From: {effectiveFrom}\nEffective To: {effectiveTo}\nType of doc: {type}";
        }
    }
}

 
