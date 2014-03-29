using System;

namespace MobilePhone.Library
{
    public class Call
    {
        private DateTime? dateAndTime;
        private string dialedNumber;
        private int duration;

        public Call(DateTime? dateAndTime, string dialedNumber, int duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public Call(): this(null, null, 0)
        {
        }

        public override string ToString()
        {
            return string.Format("Call Details\n Date and Time: {0}\n Dialed Number: {1}\n Duration: {2}\n"
                , this.DateAndTime, this.DialedNumber, this.Duration);
        }

        public DateTime? DateAndTime
        {
            get 
            { 
                return this.dateAndTime; 
            }
            set 
            { 
                this.dateAndTime = value; 
            }
        }

        public string DialedNumber
        {
            get 
            { 
                return this.dialedNumber; 
            }
            set 
            { 
                this.dialedNumber = value; 
            }
        }

        public int Duration
        {
            get 
            { 
                return duration; 
            }
            set 
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Invalid argument: Duration should not be a negative number.");
                }
                duration = value; 
            }
        }
        
    }
}
