using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class SilverCard: ICreditCard
    {
        public string getName()
        {
            return "Silver";
        }

        public void accept(IOfferVisitor v)
        {
            v.visitSilverCard(this);
        }
    }
}
