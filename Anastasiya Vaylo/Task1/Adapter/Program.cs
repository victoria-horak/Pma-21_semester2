using System;

namespace Adapter
{
    class MainApp
    {
        static void Main()
        {
            HumanAdapter adapter1 = new HumanAdapter();
            adapter1.Eat();

            AnimalAdapter adapter2 = new AnimalAdapter();
            adapter2.Eat();

        }
    }
}