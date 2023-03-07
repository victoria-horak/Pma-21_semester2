using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Adapter
    {
        private Document forAdapting;

        public Adapter(Document forAdapting)
        {
            this.forAdapting = forAdapting;
        }
        public FilteredType Adapting()
        {
            return new FilteredType
            {
                identificatorId = forAdapting.identificatorId,
                objectId = forAdapting.dataItem.objectId,
                effectiveFrom = DateTime.Parse(forAdapting.dataItem.effectiveFrom),
                effectiveTo = DateTime.Parse(forAdapting.dataItem.effectiveTo),
                type = forAdapting.info.type
            };
        }
    }
}
