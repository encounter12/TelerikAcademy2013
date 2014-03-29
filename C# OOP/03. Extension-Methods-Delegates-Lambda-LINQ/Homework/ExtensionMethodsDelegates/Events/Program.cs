using System;
using System.Timers;

namespace Events
{
    class Program
    {
        static readonly double timeInterval = 3;
        static double elapsedTime = timeInterval;

        static void Main()
        {
            Console.WriteLine("This example uses Events to display message on the screen every {0} seconds:", timeInterval);

            Timer myTimer = new Timer(timeInterval * 1000);
            myTimer.Elapsed += new ElapsedEventHandler(WriteMessage);
            myTimer.Start();
            Console.ReadKey();
        }

        static void WriteMessage(object source, ElapsedEventArgs e)
        {
            
            Console.WriteLine("{0} seconds have elapsed", elapsedTime);
            elapsedTime += timeInterval;
        }
    }
}
