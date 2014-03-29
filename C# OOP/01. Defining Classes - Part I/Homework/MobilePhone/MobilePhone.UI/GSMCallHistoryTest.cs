using System;
using MobilePhone.Library;

namespace MobilePhone.UI
{
    public class GSMCallHistoryTest
    {
        private static GSM gsm;
        private static decimal pricePerMinute = 0.37m;

        public static void CreateSingleGSM()
        {
            gsm = new GSM("One", "HTC", 300, "Ivo", new Battery(), new Display(3.7f, 14000000));           
        }

        public static void AddCalls()
        {
            gsm.AddCallToHistory(new Call(new DateTime(2013, 09, 23, 14, 15, 3), "0896341256", 94));
            gsm.AddCallToHistory(new Call(new DateTime(2013, 07, 13, 8, 45, 38), "0882142378", 168));

        }

        public static void DisplayCallsInfo()
        {
            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }
        }

        public static void DisplayCallsTotalPrice()
        {
            Console.WriteLine("\nCalls Total Price: {0:F2}", gsm.CalculateCallsTotalPrice(pricePerMinute));
        }

        public static void RemoveLongestCall()
        {
            gsm.RemoveLongestCallFromHistory();
        }

        public static void ClearCallHistory()
        {
            gsm.ClearCallHistory();
        }
       
    }
}
