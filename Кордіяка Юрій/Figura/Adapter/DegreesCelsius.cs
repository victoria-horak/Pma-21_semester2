namespace Adapter
{
    public class DegreesCelsius:IDegrees
    {
        public double currentDegrres;

        public DegreesCelsius(double degrees)
        {
            this.currentDegrres = degrees;
        }
        public double GetDegrees()
        {
            return this.currentDegrres;
        }
    }
}