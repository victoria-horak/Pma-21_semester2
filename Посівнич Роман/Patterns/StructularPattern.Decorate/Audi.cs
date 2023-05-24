namespace StructularPattern.Decorate_
{
    class Audi : Car
    {
        public Audi()
        {
            BrandName = "Audi";
        }
        public override void Go()
        {
            Console.WriteLine("Car " + BrandName + " and car receive...");
        }
    }
}


