using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    public class ParfumeType
    {
        string brand;
        string fragranceNotes;

        public ParfumeType()
        {
            this.brand = "";
            this.fragranceNotes = "";
        }

        public ParfumeType(string brand, string fragranceNotes)
        {
            this.brand = brand;
            this.fragranceNotes = fragranceNotes;
        }

        
        public override string ToString()
        {
            return $"Brand: {brand}, Fragrance Notes: {fragranceNotes}";
        }
    }
}
