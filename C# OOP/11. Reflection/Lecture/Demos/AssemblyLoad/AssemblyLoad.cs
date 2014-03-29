using System;
using System.Reflection;

class AssemblyLoad
{
    static void Main()
    {
        // List all assemblies at the beginning
        Console.WriteLine(" ------------------- In the beginning --------------------");
        ShowAllAsemblies();

        // Load the "System" assembly with Assembly.Load()
        Assembly.Load("System");

        // List all assemblies again
        Console.WriteLine("------ After loading the 'System' assembly with Assembly.Load() ------");
        ShowAllAsemblies();

        // Load assembly System.Numerics.dll
        Assembly.LoadFrom(@"..\..\Lib\System.Numerics.dll");
        Console.WriteLine(" --- After loading assembly System.Numerics.dll ---");

        // List all assemblies once again
        ShowAllAsemblies();
		
		// Try loading 32-bit assembly in 64-bit .NET Framework
		//Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll");
    }

    static private void ShowAllAsemblies()
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.Location);
            Console.WriteLine();
        }
    }
}
