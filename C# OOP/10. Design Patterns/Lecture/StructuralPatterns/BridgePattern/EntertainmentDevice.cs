using System;

namespace BridgePattern
{
    // Implementor
    public abstract class EntertainmentDevice
    {
        // Current chanel/chapter
        public int DeviceState { get; set; }

        // Max number of channels/chapters
        public int MaxSetting { get; set; }

        public int VolumeLevel { get; set; }

        public abstract void BtnFivePressed();

        public abstract void BtnSixPressed();

        public void DeviceInfo()
        {
            if (DeviceState > MaxSetting || DeviceState < 0)
            {
                DeviceState = 0;
            }

            Console.WriteLine("On {0}", DeviceState);
        }

        public void BtnSevenPressed()
        {
            VolumeLevel++;

            Console.WriteLine("Volume at: {0}", VolumeLevel);
        }

        public void BtnEightPressed()
        {
            VolumeLevel++;

            Console.WriteLine("Volume at: {0}", VolumeLevel);
        }
    }
}