using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class SomeObject
    {
        public int identificatorId { get; set; }
        public DataItem dataItem { get; set; }
        public Info info { get; set; }
        public SomeObject() { }
        public SomeObject(string identificatorId, string objectId, string effectimeFrom, string effectiveTo, string type)
        {
            this.identificatorId = Convert.ToInt32(identificatorId);
            this.dataItem.objectId = objectId;
            this.dataItem.effectimeFrom = Convert.ToDateTime(effectimeFrom);
            this.dataItem.effectiveTo = Convert.ToDateTime(effectiveTo);
            this.info.type = type;
        }
    }
}
