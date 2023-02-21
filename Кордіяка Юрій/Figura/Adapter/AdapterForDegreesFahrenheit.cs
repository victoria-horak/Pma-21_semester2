using System;
using System.Text.RegularExpressions;

namespace Adapter
{
    public class AdapterForDegreesFahrenheit : IDegrees
    {
        DegreesFahrenheit DegreesFahrenheit;

        public AdapterForDegreesFahrenheit(DegreesFahrenheit degreesFahrenheit)
        {
            this.DegreesFahrenheit = degreesFahrenheit;
        }

        public double GetDegrees()
        {
            return Math.Round(5.0 / 9.0 * (DegreesFahrenheit.GetDegrees() - 32), 1);
        }
    }
}