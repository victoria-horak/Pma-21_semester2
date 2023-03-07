using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class BronzeCard: ICreditCard
    {
        public string getName()
        {
            return "Bronze";
        }
        public void accept(IOfferVisitor v)
        {
            v.visitBronzeCard(this);
        }
    }
}
