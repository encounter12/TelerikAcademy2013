using System;

namespace Delegates
{
    class Program
    {
        //TimerDelegate and TestMethod are defined in the Timer class file
        static void Main()
        {

            int time = 3;

            Console.WriteLine("This example uses Events to display message on the screen every {0} seconds:", time);

            //creating object of type TimerDelegate with parameter TestMethod

            Timer.TimerDelegate d = new Timer.TimerDelegate(Timer.TestMethod);

            //the delegate object calls "TestMethod" and assigns "time" as its parameter
            d(time);
        }
    }
}
