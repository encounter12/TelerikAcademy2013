using System;
using System.Reflection;

class AssemblyTypesDemo
{
    struct SomeStructure
    {
        class SoneInnerClass
        {
        }
    }

    public void SomePublicMethod()
    {
        // Some code
    }

    private void SomePrivateMethod()
    {
        // Some code
    }

    private static void SomeStaticMethod()
    {
        // Some code
    }

    static void Main()
    {
        Assembly currentAssembly;
        currentAssembly = Assembly.GetExecutingAssembly();
						
        foreach (Type type in currentAssembly.GetTypes())
        {
            MemberInfo[] members = type.FindMembers(
                MemberTypes.All,
                BindingFlags.NonPublic | BindingFlags.Static,
                Type.FilterName, "*");

            foreach (MemberInfo member in members)
            {
                Console.WriteLine("{0}.{1}", type.Name, member.Name);
            }

            Console.WriteLine();
        }
    }
}
