using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeyboradFactory keyboradFactory = null;
            KeyBoard keyBoard = null;

            keyboradFactory = new HyperXKeyBoardFactory();
            keyBoard = keyboradFactory.createKeyBoard();

            Console.WriteLine($"Name of the keyboard: {keyBoard.getKeybordName()}");
            Console.WriteLine($"Type keyboard: {keyBoard.getKeybordType()}");
            Console.WriteLine($"Number of clicks: {keyBoard.getKeybordNumberOfClicks()}");

            Console.WriteLine("-----------------------------------------------------------\n");

            keyboradFactory = new RazorKeyBoardFactory();
            keyBoard = keyboradFactory.createKeyBoard();
            Console.WriteLine($"Name of the keyboard: {keyBoard.getKeybordName()}");
            Console.WriteLine($"Type keyboard: {keyBoard.getKeybordType()}");
            Console.WriteLine($"Number of clicks: {keyBoard.getKeybordNumberOfClicks()}");

            Console.WriteLine("-----------------------------------------------------------\n");

            keyboradFactory = new MSIKeyBoardFactory();
            keyBoard = keyboradFactory.createKeyBoard();
            Console.WriteLine($"Name of the keyboard: {keyBoard.getKeybordName()}");
            Console.WriteLine($"Type keyboard: {keyBoard.getKeybordType()}");
            Console.WriteLine($"Number of clicks: {keyBoard.getKeybordNumberOfClicks()}");

        }
    }
}
