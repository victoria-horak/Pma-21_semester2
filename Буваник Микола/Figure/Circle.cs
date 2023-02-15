namespace Project1;

class Circle : Figure
{
    public Circle(double firstSide) : base(firstSide)
    {
    }

    public override double GetArea()
    {
        return Double.Pi * FirstSide * FirstSide;
    }

    public override double GetPerimeter()
    {
        return 2 * Double.Pi * FirstSide;
    }
    
    public override void Print()
    {
        Console.WriteLine("Circle\t\tArea={0}\tPerimetr={1}",GetArea(),GetPerimeter());
    }
}