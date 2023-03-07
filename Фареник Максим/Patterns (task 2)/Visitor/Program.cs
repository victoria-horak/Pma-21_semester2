using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IOfferVisitor firstVisitor = new HotelOffer();
            IOfferVisitor secondVisitor = new GasOffer();

            ICreditCard bronze = new BronzeCard();
            ICreditCard silver = new SilverCard();
            ICreditCard gold = new GoldCard();

            bronze.accept(firstVisitor);
            gold.accept(firstVisitor);
            silver.accept(secondVisitor);
        }
    }
}
