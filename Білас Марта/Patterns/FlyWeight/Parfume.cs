using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    public class Parfume
    {
        int price;
        int volume;
        ParfumeType parfumeType;

        public Parfume(int price, int volume, ParfumeType parfumeType)
        {
            this.price = price;
            this.volume = volume;
            this.parfumeType = parfumeType;
        }
        public void show()
        {
            Console.WriteLine( $"Parfume Type: {parfumeType.ToString()}, Price: {price}, Volume: {volume}");
        }
    }
}
