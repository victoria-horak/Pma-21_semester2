using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Adapter
    {
        private ItemInfo toAdapt;

        public Adapter(ItemInfo toAdapt)
        {
            this.toAdapt=toAdapt;
        }

        public NewType Adapt()
        {
            return new NewType
            {
                identificatorId = toAdapt.identificatorId,
                effectiveFrom = DateTime.Parse(toAdapt.dataItem.effectiveFrom),
                effectiveTo = DateTime.Parse(toAdapt.dataItem.effectiveTo),
                type = toAdapt.info.type,
                objectId = toAdapt.dataItem.objectId
            };

        }
    }
}
