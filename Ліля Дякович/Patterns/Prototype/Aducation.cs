using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable]
    public class Aducation
    {
        public string University;
        public string Faculty;
        public int Course;
        public override string ToString()
        {
            return $"University: {University}, Faculty: {Faculty}, Course: {Course}";
        }
    }
}
