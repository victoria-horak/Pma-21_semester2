using System;

namespace testingProgram
{
    public class Adapter
    {
        private Root adapt;

        public Adapter(Root adapt)
        {
            this.adapt = adapt;
        }

        public AllInfo Adapt()
        {
            return new AllInfo
            {
                identificatorId = adapt.identificatorId,
                effectiveFrom = DateTime.Parse(adapt.dataItem.effectiveFrom),
                effectiveTo = DateTime.Parse(adapt.dataItem.effectiveTo),
                type = adapt.info.type,
                objectId = adapt.dataItem.objectId
            };

        }
    }
}
