using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public class Program
    {
        static void Main()
        {
            string csharpCode = HTMLRendererCommandExecutor.ReadInputCSharpCode();
            HTMLRendererCommandExecutor.CompileAndRun(csharpCode);
        }
    }
}
