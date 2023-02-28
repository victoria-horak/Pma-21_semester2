using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal abstract class State
    {
        protected TicketBooking context;

        public State(TicketBooking context)
        {
            this.context = context;
        }

        public abstract string BookTicket(string passengerName);
        public abstract string CancelBooking(string passengerName);
    }
}
