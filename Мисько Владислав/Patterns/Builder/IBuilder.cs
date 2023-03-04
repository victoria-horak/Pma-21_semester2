namespace DesignPattern_Builder
{
    public interface IBuilder<T>
        where T : class
    {
        public void reset();
        public void setSeats(int numberOfSeats);
        public void setEngine(CarEngine engine);
        public void setTripComputer(bool shouldSet);
        public void setGPS(bool shouldSet);
        public T giveReadyProduct();
    }
}
