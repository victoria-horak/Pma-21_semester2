using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class AvailableState: State
    {
        public AvailableState(TicketBooking context) : base(context)
        {
        }

        public override string BookTicket(string passengerName)
        {
            context.GetPassengersList().Add(passengerName);
            context.ChangeState(new BookedState(context));
            return $"Ticket booked for {passengerName}";
        }

        public override string CancelBooking(string passengerName)
        {
            return $"No booking available for {passengerName}";
        }
    }
}
