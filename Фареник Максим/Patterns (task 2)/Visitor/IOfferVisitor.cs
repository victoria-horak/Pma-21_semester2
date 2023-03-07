using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal interface IOfferVisitor
    {
        void visitBronzeCard(BronzeCard bronzeCard);
        void visitSilverCard(SilverCard silverCard);
        void visitGoldCard(GoldCard goldCard);
    }
}
