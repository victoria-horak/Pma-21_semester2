using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class WorkerA : BaseWorker
    {
        public WorkerA(string name, string surname, IMediator mediator = null) : base(name, surname, mediator) { }
        public override void sendMessage(string message)
        {
            Console.WriteLine($"WorkerA {Name} {Surname} sends message: " + message);
            mediator.notify(this, message);
        }

        public override void receiveMessage(string message)
        {
            Console.WriteLine($" WorkerA {Name} {Surname} receives message: " + message);
        }
    }
}
