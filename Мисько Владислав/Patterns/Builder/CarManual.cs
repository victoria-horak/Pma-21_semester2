namespace DesignPattern_Builder
{
    public class CarManual
    {
        public string seatsInfo { get; set; }
        public string tripComputerInfo { get; set; }
        public string GPSInfo { get; set; }
        public string engineInfo { get; set; }
        public override string ToString()
        {
            return $"{seatsInfo}\n{tripComputerInfo}\n{GPSInfo}\n{engineInfo}"; 
        }
    }
}
