using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Phones_.Handlers
{
    internal class UnsupportedRequestHandler : BasePhoneHandler
    {
        public override void HandleRequest(string request)
        {
            Console.WriteLine("This program don`t support such request");
        }
    }
}
