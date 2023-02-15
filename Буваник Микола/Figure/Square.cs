namespace Project1;

class Square:Rectangle
{
    public Square(double firstSide) : base(firstSide, firstSide){}
    public override void Print()
    {
        Console.WriteLine("Square\t\tArea={0}\tPerimetr={1}",GetArea(),GetPerimeter());
    }
}