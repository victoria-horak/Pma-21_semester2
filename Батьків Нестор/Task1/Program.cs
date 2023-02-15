class Start
{
    public static void Main(string[] args)
    {
        Shape[] figures = { new Rectange(2, 3), new Circle(4), new Square(6) };
        for (int i = 0; i < figures.GetLength(0); i++)
        {
            Console.WriteLine(figures[i].display());
        }
    }
}

interface IPerimeter
{
    double getPerimeter();
}

interface IArea
{
    double getArea();
}

abstract class Shape : IArea, IPerimeter
{
    protected int sideA;
    public Shape(int sideA)
    {
        this.sideA = sideA;
    }
    public abstract double getArea();
    public abstract double getPerimeter();
    public abstract string display();
}

class Rectange : Shape
{
    private int sideB;
    public Rectange(int sideA, int sideB) : base(sideA)
    {

        this.sideB = sideB;
    }
    public override double getArea()
    {
        return this.sideA * this.sideB;
    }
    public override double getPerimeter()
    {
        return (this.sideA + this.sideB) * 2;
    }
    public override string display()
    {
        return $"Shape : rectangle,\nArea {this.getArea()},\nPerimeter {this.getPerimeter()}\n";
    }
}

class Circle : Shape
{
    public Circle(int sideA) : base(sideA) { }

    public override double getArea()
    {
        return Math.PI * this.sideA * this.sideA;
    }
    public override double getPerimeter()
    {
        return Math.PI * this.sideA * 2;
    }
    public override string display()
    {
        return $"Shape : circle,\nArea {this.getArea()},\nPerimeter {this.getPerimeter()}\n";
    }
}

class Square : Rectange
{
    public Square(int sideA) : base(sideA, sideA) { }

    public override string display()
    {
        return $"Shape : square,\nArea {this.getArea()},\nPerimeter {this.getPerimeter()}\n";
    }
}