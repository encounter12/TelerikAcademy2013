namespace BridgePattern
{
    // Abstraction
    public abstract class RemoteButton
    {
        private EntertainmentDevice device;

        public RemoteButton(EntertainmentDevice device)
        {
            this.device = device;
        }

        public void BtnFivePressed()
        {
            device.BtnFivePressed();
        }

        public void BtnSixPressed()
        {
            device.BtnSixPressed();
        }

        public void DeviceInfo()
        {
            device.DeviceInfo();
        }

        public abstract void BtnNinePressed();
    }
}