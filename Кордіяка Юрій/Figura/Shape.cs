namespace ConsoleApplication1

{
    abstract class Shape : IPerimeter, IArea
    {
        protected double Side;
        public Shape(double Side)
        {
            this.Side = Side;
        }
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract string Print();
    }
}