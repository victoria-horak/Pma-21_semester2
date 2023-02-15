namespace Project1;

abstract class Figure : IArea, IParimeter
{
    protected double FirstSide;

    protected Figure(double firstSide)
    {
        FirstSide = firstSide;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();
    public abstract void Print();
}