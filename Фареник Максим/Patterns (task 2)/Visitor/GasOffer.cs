using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class GasOffer: IOfferVisitor
    {
        public void visitBronzeCard(BronzeCard bronzeCard)
        {
            Console.WriteLine("Computing the cashback for a bronze card buying gas");
        }
        public void visitSilverCard(SilverCard silverCard)
        {
            Console.WriteLine("Computing the cashback for a silver card buying gas");
        }
        public void visitGoldCard(GoldCard goldCard)
        {
            Console.WriteLine("Computing the cashback for a gold card buying gas");
        }
    }
}
