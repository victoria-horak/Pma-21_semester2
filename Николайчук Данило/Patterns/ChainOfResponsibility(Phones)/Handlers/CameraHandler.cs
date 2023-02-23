using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Phones_.Handlers
{
    internal class CameraHandler : BasePhoneHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "camera")
            {
                Console.WriteLine("Rear camera: 12MP, Front camera: 7MP");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }
}
