namespace DesignPattern_Builder
{
    public class CarBuilder : IBuilder<Car>
    {
        private Car product;
        public Car giveReadyProduct()
        {
            return product;           
        }

        public void reset()
        {
            product = new Car();
        }

        public void setEngine(CarEngine engine)
        {
            product.engine = engine;
        }

        public void setGPS(bool shouldSet)
        {
            product.hasGPS = shouldSet;
        }

        public void setSeats(int numberOfSeats)
        {
            product.seats = numberOfSeats;
        }

        public void setTripComputer(bool shouldSet)
        {
            product.hasTripComputer = shouldSet;
        }
    }
}
