namespace DesignPattern_Builder
{
    public class CarManualBuilder : IBuilder<CarManual>
    {
        private CarManual product;
        public CarManual giveReadyProduct()
        {
            return product;
        }

        public void reset()
        {
            product = new CarManual();
        }

        public void setEngine(CarEngine engine)
        {
            product.engineInfo = engine.ToString();
        }

        public void setGPS(bool shouldSet)
        {
            product.GPSInfo = $"The car has {(shouldSet ? "" : "no ")}GPS.";
        }

        public void setSeats(int numberOfSeats)
        {
            product.seatsInfo = $"The car has {numberOfSeats} seats.";
        }

        public void setTripComputer(bool shouldSet)
        {
            product.tripComputerInfo = $"The car has {(shouldSet ? "" : "no ")}trip computer.";
        }
    }
}
