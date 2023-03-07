using System;

namespace LinQJson
{
    class InfoImpotant 
    {
        public int identificatorId { get; set; }
        public string objectId { get; set; }
        public DateTime effectimeFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return $"id: {identificatorId}\neffectiveTo: {effectiveTo}\neffectiveFrom: {effectimeFrom}\ntype: {type}\nobjectId: {objectId}\n";
        }

    }
}
