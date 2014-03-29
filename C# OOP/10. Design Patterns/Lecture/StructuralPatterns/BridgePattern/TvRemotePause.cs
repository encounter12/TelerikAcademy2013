using System;

namespace BridgePattern
{
    public class TvRemotePause : RemoteButton
    {
        public TvRemotePause(EntertainmentDevice device)
            : base(device)
        {
        }

        public override void BtnNinePressed()
        {
            Console.WriteLine("TV was Paused");
        }
    }
}