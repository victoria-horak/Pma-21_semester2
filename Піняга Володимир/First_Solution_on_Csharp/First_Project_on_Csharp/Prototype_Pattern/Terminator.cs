using System;

namespace Prototype_Pattern
{
    class Terminator : IRobot
    {
        private string name;
        public Terminator() { }
        public Terminator(string _name) { name = _name; }
        public string GetName() => name;
        public void SetName(string name) { this.name = name; }
        public IRobot clone()
        {
            return (IRobot)this.MemberwiseClone();
        }
    }
}
