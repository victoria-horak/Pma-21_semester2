namespace DesignPattern_Builder
{
    public class CarEngine
    {
        public string name { get; set; }
        public double volume { get; set; }
        public CarEngine(string name, double volume)
        {
            this.name = name;
            this.volume = volume;   
        }
        public override string ToString()
        {
            return $"Car engine name: {name}. Volume: {volume}";
        }
    }
}
