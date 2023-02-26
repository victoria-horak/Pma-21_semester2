using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    abstract public class BaseWorker
    {
        protected IMediator mediator;
        public string Name { get; set; }
        public string Surname { get; set; }

        public BaseWorker(string name, string surname, IMediator mediator = null)
        {
            this.mediator = mediator;
            this.Name = name;
            this.Surname = surname;
        }
        public void setMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        abstract public void sendMessage(string message);
        abstract public void receiveMessage(string message);
    }
}
