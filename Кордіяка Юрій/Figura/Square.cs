namespace ConsoleApplication1
{
    class Square : Reactangle
    {
        public Square(double sideA) : base(sideA, sideA){}

        public override string Print()
        {
            return "Square\n" + "perimeter=" + GetPerimeter() + "\n" + "area=" + GetArea();
        }

        public override double GetArea()
        {
            return 4 * sideB;
        }

        public override double GetPerimeter()
        {
            return sideB * sideB;
        }
    }
}