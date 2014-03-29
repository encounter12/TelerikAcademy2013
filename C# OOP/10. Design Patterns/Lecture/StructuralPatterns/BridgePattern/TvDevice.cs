using System;

namespace BridgePattern
{
    //Concrete Implementor
    public class TvDevice : EntertainmentDevice
    {
        public TvDevice(int state, int maxSetting)
        {
            DeviceState = state;
            MaxSetting = maxSetting;
        }

        public override void BtnFivePressed()
        {
            Console.WriteLine("Channel Down");

            DeviceState--;
        }

        public override void BtnSixPressed()
        {
            Console.WriteLine("Channel Up");

            DeviceState++;
        }
    }
}