namespace Adapter
{
    public class DegreesFahrenheit
    {
        public double currentDegrres;

        public DegreesFahrenheit(double degrees)
        {
            this.currentDegrres = degrees;
        }
        public double GetDegrees()
        {
            return this.currentDegrres;
        }
    }
}