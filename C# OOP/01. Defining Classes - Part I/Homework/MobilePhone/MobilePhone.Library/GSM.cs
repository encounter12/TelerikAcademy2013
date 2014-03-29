using System;
using System.Collections.Generic;

namespace MobilePhone.Library
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S = new GSM("iPhone 4S", "Apple", 400, "Sami", new Battery(), new Display(3.5f, 16000000));
        private List<Call> callHistory;

        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer): this(model, manufacturer, null, null, new Battery(), new Display())
        {            
        }
                
        public override string ToString()
        {
            return string.Format("GSM Details\n Model: {0}\n Manufacturer: {1}\n Price: {2}\n Owner: {3}\n{4}{5}"
                , this.Model, this.Manufacturer, this.Price, this.Owner, this.Battery, this.Display);
        }

        public void AddCallToHistory(Call call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCallFromHistory(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void RemoveLongestCallFromHistory()
        {
            if (this.callHistory.Count == 0)
            {
                return;
            }

            int longestCallIndex = 0;
            int longestCallDuration = -1;
            
            foreach (Call call in this.callHistory)
            {
                if (call.Duration > longestCallDuration)
                {
                    longestCallDuration = call.Duration;
                    longestCallIndex = this.callHistory.IndexOf(call);
                }

            }
            
            this.callHistory.RemoveAt(longestCallIndex);

        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateCallsTotalPrice(decimal pricePerMinute)
        {
            decimal callsTotalPrice = 0;
                
            foreach (Call call in callHistory)
            {
                callsTotalPrice += (call.Duration / 60m) * pricePerMinute;                                     
            }
            return callsTotalPrice;
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Invalid argument: Price should be a positive number.");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
            set
            {
                iPhone4S = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }        

    }
}
