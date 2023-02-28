using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class BookedState: State
    {
        public BookedState(TicketBooking context) : base(context)
        {
        }

        public override string BookTicket(string passengerName)
        {
            return $"Ticket already booked for {context.GetPassengersList()[0]}";
        }

        public override string CancelBooking(string passengerName)
        {
            if (context.GetPassengersList()[0] == passengerName)
            {
                context.GetPassengersList().Remove(passengerName);
                context.ChangeState(new AvailableState(context));
                return $"Booking cancelled for {passengerName}";
            }
            else
            {
                return $"Cannot cancel booking for {passengerName}. Booking is held by {context.GetPassengersList()[0]}";
            }
        }
    }
}
