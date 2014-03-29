using System;

namespace BridgePattern
{
    // Refined Abstraction
    public class TvRemoteMute : RemoteButton
    {
        public TvRemoteMute(EntertainmentDevice device)
            : base(device)
        {
        }

        public override void BtnNinePressed()
        {
            Console.WriteLine("TV was Muted");
        }
    }
}