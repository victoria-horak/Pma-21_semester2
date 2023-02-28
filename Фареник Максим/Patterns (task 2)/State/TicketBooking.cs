using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class TicketBooking
    {
        private State currentState;
        private List<string> passengers = new List<string>();

        public TicketBooking()
        {
            this.currentState = new AvailableState(this);
        }

        public void ChangeState(State newState)
        {
            this.currentState = newState;
        }

        public string BookTicket(string passengerName)
        {
            return this.currentState.BookTicket(passengerName);
        }

        public string CancelBooking(string passengerName)
        {
            return this.currentState.CancelBooking(passengerName);
        }

        public List<string> GetPassengersList()
        {
            return this.passengers;
        }

        public State GetState()
        {
            return this.currentState;
        }
    }
}
