using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Phones_.Handlers
{
    internal class StorageHandler : BasePhoneHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "storage")
            {
                Console.WriteLine("Available storage: 64GB");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }
}
