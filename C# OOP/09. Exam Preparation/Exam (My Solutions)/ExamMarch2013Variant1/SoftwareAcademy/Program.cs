using System;
using System.Linq;

namespace SoftwareAcademy
{
    class Program
    {
        static void Main()
        {
            string csharpCode = SoftwareAcademyCommandExecutor.ReadInputCSharpCode();
            SoftwareAcademyCommandExecutor.CompileAndRun(csharpCode);
        }
    }
}