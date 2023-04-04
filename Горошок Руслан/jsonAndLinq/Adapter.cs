using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonandLinq
{
    class Adapter
    {
        private IdentificatorId adapter;

        public Adapter(IdentificatorId adapter)
        {
            this.adapter = adapter;
        }
        public NewUnification Adapt()
        {
            NewUnification newUnification = new NewUnification();

            newUnification.identificatorId = adapter.identificatorId; 
            newUnification.type = adapter.info.type;
            newUnification.effectiveFrom = Convert.ToDateTime(adapter.dataItem.effectiveFrom);
            newUnification.effectiveTo = Convert.ToDateTime(adapter.dataItem.effectiveTo);
            newUnification.objectId = adapter.dataItem.objectId;

            return newUnification;
        }
    }
}
