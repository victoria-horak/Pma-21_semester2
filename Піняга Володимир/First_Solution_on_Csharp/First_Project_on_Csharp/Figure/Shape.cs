using System;


namespace First_Project_on_Csharp
{
    abstract class Shape: IArea, IPerimeter
    {
        public double side1; //харатеристика
        public abstract double Square();
        public abstract double Perimeter();
        public abstract void print();
    }
}
