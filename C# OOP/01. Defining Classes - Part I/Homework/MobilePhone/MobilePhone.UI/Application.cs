using System;

namespace MobilePhone.UI
{
    public class Application
    {
        static void Main()
        {            
            GSMTest.CreateGSMs();
            
            GSMTest.DisplayGSMsInformation();
            
            GSMTest.DisplayIPhone4SDetails();

            GSMCallHistoryTest.CreateSingleGSM();
            
            GSMCallHistoryTest.AddCalls();
            
            GSMCallHistoryTest.DisplayCallsInfo();
            
            GSMCallHistoryTest.DisplayCallsTotalPrice();            
            
            GSMCallHistoryTest.RemoveLongestCall();
            
            GSMCallHistoryTest.DisplayCallsTotalPrice();
            
            GSMCallHistoryTest.ClearCallHistory();
            
            GSMCallHistoryTest.DisplayCallsInfo();
        }
    }
}