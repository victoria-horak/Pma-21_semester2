using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility_Phones_
{
    internal interface IPhoneHandler
    {
        void HandleRequest(string request);
        IPhoneHandler SetNext(IPhoneHandler handler);
    }
}
