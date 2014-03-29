using System;

namespace MobilePhone.Library
{
   
    public class Battery
    {
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;
       
        public enum BatteryType
        {
            LiIon, NiMH, NiCd
        }

        private BatteryType? typeOfBattery;
        
        public Battery(string model, float? hoursIdle, float? hoursTalk, BatteryType? typeOfBattery)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.TypeOfBattery = typeOfBattery;
        }
        
        public Battery(): this(null, null, null, null)
        {            
        }

        public override string ToString()
        {
            return string.Format("Battery Details\n Model: {0}\n Hours Idle: {1}\n Hours Talk: {2}\n Type: {3}\n"
                , this.Model, this.hoursIdle, this.hoursTalk, this.TypeOfBattery);
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public float? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {

                if (value != null && value < 0)
                {
                    throw new ArgumentException("Invalid argument: Hours idle should not be a negative number.");
                }
                
                this.hoursIdle = value;
            }
        }

        public float? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Invalid argument: Hours Talk should not be a negative number.");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType? TypeOfBattery
        {
            get
            {
                return this.typeOfBattery;
            }
            set
            {
                if (value != null && value != BatteryType.LiIon && value != BatteryType.NiMH && value != BatteryType.NiCd)
                {
                    throw new ArgumentException("Invalid Battery Type. Please use: LiIon, NiMH, NiCd");
                }

                this.typeOfBattery = value;
            }
        }
    }
}
