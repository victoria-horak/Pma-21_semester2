namespace Figures
{
    abstract class Figure : ISquare, IPerimeter
    {
        protected double side;

        public Figure(double side)
        {
            this.side = side;
        }
        public abstract double perimetr();
        public abstract double area();
        public abstract void print();
    }
}
