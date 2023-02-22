using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    interface IProduction
    {
        void Release();
    }

    class Car : IProduction
    {
        public void Release() => Console.WriteLine("Випущено нове авто!");

    }

    class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Випущено новий грузовик!");         
    }

    interface IWorkShop //абстрактний цех для виготівлі авто
    {
        IProduction Create();
    }

    class CarWorkShop: IWorkShop
    {
        public IProduction Create() => new Car();
    }

    class TruckWorkShop: IWorkShop
    {
        public IProduction Create() => new Truck();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IWorkShop creator = new CarWorkShop();
            IProduction car = creator.Create();
            creator = new TruckWorkShop();

            IProduction truck = creator.Create();
                
            car.Release();
            truck.Release();

           
        }
    }
}
