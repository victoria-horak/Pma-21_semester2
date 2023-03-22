using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LINQwithJSON
{
    internal class Adapter
    {
        private RequiredData adaptee;
        public Adapter(RequiredData adaptee)
        {
            this.adaptee = adaptee;
        }

        public Type Adapt()
        {
            var type = new Type();

            type.identificatorId = adaptee.identificatorId;
            type.objectId = adaptee.dataItem.objectId;
            type.effectiveFrom = DateTime.Parse(adaptee.dataItem.effectiveFrom);
            type.effectiveTo = DateTime.Parse(adaptee.dataItem.effectiveTo);
            type.type = adaptee.info.type;

            return type;
        }
    }
}
