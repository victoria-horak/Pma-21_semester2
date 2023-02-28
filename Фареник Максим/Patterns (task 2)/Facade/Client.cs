using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Facade _facade= new Facade();
            _facade.Operation();
        }
        
    }
}
