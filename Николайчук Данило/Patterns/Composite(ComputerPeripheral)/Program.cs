using Composite_goods_;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        try
        {
            IPeripheral mouse = new ComputerPeripherals("Mouse", 20);
            IPeripheral keyboard = new ComputerPeripherals("Keyboard", 30);

            IPeripheral MouseKeyboardBOX = new BoxWithComputerPeripherals("MouseKeyboard BOX");
            MouseKeyboardBOX.AddPeripheral(mouse);
            MouseKeyboardBOX.AddPeripheral(keyboard);

            IPeripheral monitor = new ComputerPeripherals("Monitor", 100);
            IPeripheral charging = new ComputerPeripherals("Charging", 5);
            IPeripheral HDMICord = new ComputerPeripherals("HDMICord", 5);

            IPeripheral MonitorBOX = new BoxWithComputerPeripherals("Monitor BOX");
            MonitorBOX.AddPeripheral(MouseKeyboardBOX);
            MonitorBOX.AddPeripheral(monitor);
            MonitorBOX.AddPeripheral(charging);
            MonitorBOX.AddPeripheral(HDMICord);

            IPeripheral computerBOX = new BoxWithComputerPeripherals("Computer BOX");
            computerBOX.AddPeripheral(MouseKeyboardBOX);
            computerBOX.AddPeripheral(MonitorBOX);

            Console.WriteLine("Full price of box: " + computerBOX.Price);
            Console.WriteLine(computerBOX);
        }
        catch(Exception ex) { Console.WriteLine("Error" + ex.ToString()); }
    }
}