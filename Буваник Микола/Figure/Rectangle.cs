namespace Project1;

class Rectangle : Figure
{
    protected double SecondSide;

    public Rectangle(double secondSide,double firstSide):base(firstSide)
    {
        SecondSide = secondSide;
    }

    public override double GetArea()
    {
        return SecondSide*FirstSide;
    }

    public override double GetPerimeter()
    {
        return (SecondSide*FirstSide)*2;
    }

    public override void Print()
    {
        Console.WriteLine("Rectangle\tArea={0}\tPerimetr={1}",GetArea(),GetPerimeter());
    }
}