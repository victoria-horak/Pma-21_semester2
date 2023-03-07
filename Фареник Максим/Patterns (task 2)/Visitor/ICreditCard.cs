using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal interface ICreditCard
    {
        string getName();
        void accept(IOfferVisitor v);
    }
}
