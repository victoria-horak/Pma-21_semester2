using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class GoldCard: ICreditCard
    {
        public string getName()
        {
            return "Gold";
        }
        public void accept(IOfferVisitor v)
        {
            v.visitGoldCard(this);
        }
    }
}
