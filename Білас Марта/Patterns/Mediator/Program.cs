using System;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkerA workerA = new WorkerA("Kum", "Vasyl");
            WorkerB workerB = new WorkerB("Kuma", "Svitlana");
            WorkerC workerC = new WorkerC("malenkiy", "Taras");

            Mediator mediator = new Mediator(workerA, workerB, workerC);
            workerA.sendMessage("I am Kum");
            workerB.sendMessage("I am Kuma");
        }
    }
}
