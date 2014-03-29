using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class Program
    {
        static void Main()
        {
            IList<string> allCommands = DocumentSystem.ReadAllCommands();
            DocumentSystem.ExecuteCommands(allCommands);
            
        }
    }
}