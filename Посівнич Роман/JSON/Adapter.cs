using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_LINQ
{
    internal class Adapter
    {
        private Item itemToMapp;
        
        public Adapter(Item item)
        {
            this.itemToMapp = item;
        }

        public TransformedItem AdaptItem()
        {

            return new TransformedItem()
            { 
                effectimeFrom = itemToMapp.dataItem.effectimeFrom, 
                effectiveTo = itemToMapp.dataItem.effectiveTo,
                identificatorId = itemToMapp.identificatorId, 
                subInfo1 = itemToMapp.info.subInfo1, 
                type = itemToMapp.info.type
            };
        }
            

    }
}
