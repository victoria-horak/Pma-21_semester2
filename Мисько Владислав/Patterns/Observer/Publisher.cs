using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Observer
{
    public class Publisher
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();
        private object currentState;

        public void subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void notifySubscribers()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(currentState);
            }
        }

        public void updateState(object newState)
        {
            this.currentState = newState;
            notifySubscribers();
        }

    }
}
