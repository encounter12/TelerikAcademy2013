using System;
using MobilePhone.Library;

namespace MobilePhone.UI
{
    public class GSMTest
    {
        private static GSM[] mobilePhones;
 
        public static void CreateGSMs()
        {
            mobilePhones = new GSM[]
            {
                new GSM("Galaxy S4", "Samsung", 5, null, null, null),
                new GSM("One", "HTC", 300, "Ivo", new Battery(), new Display(3.7f, 14000000)),
                new GSM("Lumia", "Nokia", 350, "Pencho", new Battery("RadioShack", 24f, 7f, Battery.BatteryType.LiIon), new Display(4f, 12000000))
            };                   
        }

        public static void DisplayGSMsInformation()
        {
            foreach (GSM phone in mobilePhones)
            {
                Console.WriteLine(phone);
            }
        }

        public static void DisplayIPhone4SDetails()
        {
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
