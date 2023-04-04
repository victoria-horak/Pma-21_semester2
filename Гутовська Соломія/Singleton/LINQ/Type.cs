using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQwithJSON
{
    internal class Type
    {
        public string identificatorId { get; set; }
        public string objectId { get; set; }
        public DateTime effectiveFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        public string type { get; set; }
        public override string ToString()
        {
            return $" ID: {identificatorId}\n objectId: {objectId}\n effectiveFrom: {effectiveFrom}\n effectiveTo: {effectiveTo}\n type: {type}\n";
        }
    }
}
