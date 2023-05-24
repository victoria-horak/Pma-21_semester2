namespace StructularPattern.Decorate_
{
    class DecoratorCar 
    {
        protected Car _decoratedCar;
        public DecoratorCar(Car decoratedCar)
        {
            _decoratedCar = decoratedCar;
        }
        public virtual void Go()
        {
            _decoratedCar.Go();
        }
    }
}
