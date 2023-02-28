using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Singleton
{
    public class Player
    {
        private static Player instance;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Game { get; set; }
        public double Score { get; set; }


        private Player() { }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
    }
}
