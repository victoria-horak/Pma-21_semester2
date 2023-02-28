using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBooking system = new TicketBooking();

            Console.WriteLine("Book a Ticket. Enter your name: ");
            string name1 = Console.ReadLine();
            Console.WriteLine(system.BookTicket(name1)); 

            Console.WriteLine("Book a Ticket. Enter your name: ");
            string name2 = Console.ReadLine();
            Console.WriteLine(system.BookTicket(name2));

            Console.WriteLine($"Cancel booking for {name2}: ");
            Console.WriteLine(system.CancelBooking(name2));
            Console.WriteLine($"Cancel booking for {name1}: ");
            Console.WriteLine(system.CancelBooking(name1));

            Console.WriteLine("Book a Ticket. Enter your name: ");
            string name3 = Console.ReadLine();
            Console.WriteLine(system.BookTicket(name3));
        }
    }
}
