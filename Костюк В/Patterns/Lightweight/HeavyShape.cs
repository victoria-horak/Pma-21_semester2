using System;

namespace Lightweight
{
    public class HeavyShape : IHeavyShape
    {
        public string Color { get; set; }
        public string LineStyle { get; set; }

        public HeavyShape(string color)
        {
            Color = color;
        }

        public void Draw(int x, int y, int size)
        {
            Console.WriteLine($"Drawing heavy shape at ({x}; {y}) with size {size} color {Color}");
        }
    }
}
