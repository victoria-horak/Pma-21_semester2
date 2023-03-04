namespace DesignPattern_Builder
{
    public class Car
    {
        public int seats { get; set; }
        public bool hasGPS { get; set; }
        public bool hasTripComputer { get; set; }
        public CarEngine engine { get; set; }
    }
}
