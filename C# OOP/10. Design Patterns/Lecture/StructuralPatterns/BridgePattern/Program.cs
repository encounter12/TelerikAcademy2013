using System;

namespace BridgePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RemoteButton tv = new TvRemoteMute(new TvDevice(1, 200));
            RemoteButton tv2 = new TvRemotePause(new TvDevice(1, 200));

            Console.WriteLine("Test TV with Mute");
            tv.BtnFivePressed();
            tv.BtnSixPressed();

            tv.BtnNinePressed();

            Console.WriteLine("\nTest TV with Pause");

            tv2.BtnFivePressed();
            tv2.BtnSixPressed();
            tv2.BtnSixPressed();
            tv2.BtnSixPressed();
            tv2.BtnSixPressed();

            tv2.BtnNinePressed();
        }
    }
}