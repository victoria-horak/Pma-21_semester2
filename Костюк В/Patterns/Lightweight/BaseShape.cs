using System;

namespace Lightweight
{
    public class BaseShape
    {
        private int x;
        private int y;
        private int size;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Size { get => size; set => size = value; }

        public BaseShape(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        public virtual void Draw()
        {
            Console.WriteLine($"Drawing base shape at ({X} {Y}) with size {Size}");
        }
    }
}
