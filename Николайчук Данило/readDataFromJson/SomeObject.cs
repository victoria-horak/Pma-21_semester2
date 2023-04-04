using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readDataFromJson
{
    internal class SomeObject
    {
        private string identificatorId { get; set; }
        private long objectId { get; set; }
        public DateTime effectimeFrom { get; set; }
        public DateTime effectiveTo { get; set; }
        private string twoUselessFielsd { get; set; }
        private DateTime currentAt { get; set; }
        private DateTime currentFrom { get; set; }
        private string type { get; set; }

        public SomeObject(string identificatorId, string objectId, string effectimeFrom, string effectiveTo, string twoUselessFielsd, string currentAt, string currentFrom, string type)
        {
            this.identificatorId = identificatorId;
            this.objectId = long.Parse(objectId);
            this.effectimeFrom = DateTime.Parse(effectimeFrom);
            this.effectiveTo = DateTime.Parse(effectiveTo);
            this.twoUselessFielsd = twoUselessFielsd;
            this.currentAt = DateTime.Parse(currentAt);
            this.currentFrom = DateTime.Parse(currentFrom);
            this.type = type;
        }
        public override string ToString()
        {
            return "Identificator id: " + identificatorId + "\neffectime from: " + effectimeFrom.ToString()
+ "\neffectime to: " + effectiveTo.ToString() + "\ntwo useless fielsd: " + twoUselessFielsd+"\n\n";
        }
    }
}
