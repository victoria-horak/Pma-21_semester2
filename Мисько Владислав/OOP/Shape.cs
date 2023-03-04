namespace testshit
{
    public abstract class Shape : IPerimeter, ISquare
    {
        public double side;
        public abstract void DisplayFigure();
        public abstract double getPerimeter();
        public abstract double GetSquare();
    }
}
