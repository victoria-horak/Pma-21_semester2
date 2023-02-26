using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Mediator : IMediator
    {
        private WorkerA workerA;
        private WorkerB workerB;
        private WorkerC workerC;

        public Mediator(WorkerA workerA, WorkerB workerB, WorkerC workerC)
        {
            this.workerA = workerA;
            this.workerA.setMediator(this);
            this.workerB = workerB;
            this.workerB.setMediator(this);
            this.workerC = workerC;
            this.workerC.setMediator(this);
        }
        public void notify(BaseWorker sender, string message)
        {
            if (sender == workerA)
            {
                workerB.receiveMessage(message);
                workerC.receiveMessage(message);
            }
            else if (sender == workerB)
            {
                workerA.receiveMessage(message);
                workerC.receiveMessage(message);
            }
            else if (sender == workerC)
            {
                workerA.receiveMessage(message);
                workerB.receiveMessage(message);
            }
        }
    }
}

