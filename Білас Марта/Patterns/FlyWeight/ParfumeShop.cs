using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    public class ParfumeShop
    {
        private List<Parfume> parfumes = new List<Parfume>();
        public void addParfume(int price, int volume, string brand, string fragranceNotes)
        {
            ParfumeType type = ParfumeFactory.getParfumeType(brand, fragranceNotes);
            Parfume parfume = new Parfume(price, volume, type);
            parfumes.Add(parfume);
        }

        public void showAll()
        {
            foreach(Parfume parfume in parfumes)
            {
                parfume.show();
            }
        }
    }
}
