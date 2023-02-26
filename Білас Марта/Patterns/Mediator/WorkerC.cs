using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class WorkerC : BaseWorker
    {
        public WorkerC(string name, string surname, IMediator mediator = null) : base(name, surname, mediator) { }
        public override void sendMessage(string message)
        {
            Console.WriteLine($" WorkerC {Name} {Surname} sends message: " + message);
            mediator.notify(this, message);
        }

        public override void receiveMessage(string message)
        {
            Console.WriteLine($" WorkerC {Name} {Surname} receives message: " + message);
        }
    }
}
