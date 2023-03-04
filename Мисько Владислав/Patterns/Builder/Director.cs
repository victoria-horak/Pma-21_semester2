namespace DesignPattern_Builder
{
    public static class Director<T>
        where T: class
    {
        public static void ConstructSportsCar(IBuilder<T> builder)
        {
            builder.reset();
            builder.setSeats(2);
            builder.setEngine(new CarEngine("Sports car engine", 6.4));
            builder.setTripComputer(true);
            builder.setGPS(true);
        }

        public static void ConstructOldCar(IBuilder<T> builder)
        {
            builder.reset();
            builder.setSeats(4);
            builder.setEngine(new CarEngine("Old car engine", 1.6));
            builder.setTripComputer(false);
            builder.setGPS(false);
        }

    }
}
