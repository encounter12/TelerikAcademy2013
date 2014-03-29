using System;
using System.Diagnostics;
using System.Threading;

namespace Delegates
{    
    public class Timer
    {
        public delegate void TimerDelegate(int param);

        public static void TestMethod(int timeInterval)
        {
            int elapsedTime = timeInterval;
            while (true)
            {                
                Thread.Sleep(timeInterval * 1000);
                Console.WriteLine("{0} secs have elapsed", elapsedTime);
                elapsedTime += timeInterval;
            }                        
        }
    }
}
