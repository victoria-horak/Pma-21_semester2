using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Observer
{
    public interface ISubscriber
    {
        public void Update(object context);
    }
}
