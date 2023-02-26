using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FlyWeightPattern
{
    public class ParfumeFactory
    {
        private static Dictionary<string, ParfumeType> parfumeTypes = new Dictionary<string, ParfumeType>();
        public static ParfumeType getParfumeType(string brand, string fragranceNotes)
        {
            string key = brand + fragranceNotes;
            if (parfumeTypes.ContainsKey(key))
                return parfumeTypes[key];
            else
                parfumeTypes.Add(key, new ParfumeType(brand, fragranceNotes));
                return new ParfumeType(brand, fragranceNotes);   
        }
    }
}
