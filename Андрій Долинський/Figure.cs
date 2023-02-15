
namespace Shapes
{
    abstract class Figure : IArea, IPerimeter
    {
        protected double side;

        public Figure(double side)
        {
            this.side = side;
        }
        public abstract double Perimetr();
        public abstract double Area();
        public abstract void Print();
    }
}