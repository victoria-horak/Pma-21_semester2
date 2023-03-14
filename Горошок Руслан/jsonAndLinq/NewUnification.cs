using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonandLinq
{
    public class NewUnification
    {
        public string identificatorId { get; set; }
        public DateTime effectiveFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        public string type { get; set; }
        public string objectId { get; set; }

        public string Input()
        {
            return "IdentificatorId : " + identificatorId + "\neffectiveFrom : " + effectiveFrom + "\neffectiveTo : " + effectiveTo + "\nType : " + type + "\nObjectID : " + objectId;
        }
    }
}
