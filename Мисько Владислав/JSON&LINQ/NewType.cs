using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class NewType
    {
        public string identificatorId { get; set; }
        public DateTime effectiveFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        public string type { get; set; }
        public string objectId { get; set; }
        public override string ToString()
        {
            return $"id: {identificatorId}\neffectiveFrom: {effectiveFrom}\neffectiveTo: {effectiveTo}\ntype: {type}\nobjectId: {objectId}";
        }
    }
}
