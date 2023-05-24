namespace StructularPattern.Decorate_
{
    class MilitaryCar : DecoratorCar
    {
        public MilitaryCar(Car decoratedCar) : base(decoratedCar){}
        public override void Go()
        {
            base.Go();
            Console.WriteLine("heavy armor");
          
        }
    }

}
