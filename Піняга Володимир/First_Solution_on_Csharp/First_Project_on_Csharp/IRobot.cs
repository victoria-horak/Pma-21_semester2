using System;

namespace Prototype_Pattern
{
    public interface IRobot
    {
        string GetName();
        void SetName(string name);
        IRobot clone();
    }
}
