using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class ConcreteCommand : ICommand
    {
        private Receiver _receiver;
        private string _text;

        public ConcreteCommand(Receiver receiver, string text)
        {
            _receiver = receiver;
            _text = text;
        }

        public void Execute()
        {
            _receiver.Action(_text);
        }
    }
}
