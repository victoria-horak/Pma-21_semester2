using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class HotelOffer: IOfferVisitor
    {
        public void visitBronzeCard(BronzeCard bronzeCard)
        {
            Console.WriteLine("Computing the cashback for a bronze card booking a room in hotel");
        }
        public void visitSilverCard(SilverCard silverCard)
        {
            Console.WriteLine("Computing the cashback for a silver card booking a room in hotel");
        }
        public void visitGoldCard(GoldCard goldCard)
        {
            Console.WriteLine("Computing the cashback for a gold card booking a room in hotel");
        }
    }
}
