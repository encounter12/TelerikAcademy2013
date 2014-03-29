using System;
using System.Reflection;

class DynamicInvokeDemo
{
    static void Main()
    {
        // Load the assembly mscorlib.dll
        Assembly mscorlibAssembly = Assembly.Load("mscorlib.dll");

        // Create an instance of DateTime by calling new DateTime(2010, 1, 5)
        Type systemDateTimeType = mscorlibAssembly.GetType("System.DateTime");

        object[] constructorParams = new object[] { 2010, 1, 5 };
        object dateTimeInstance = Activator.CreateInstance(systemDateTimeType, constructorParams);

        // Invoke DateTime.AddDays(10)
        Type[] addDaysParamsTypes = new Type[] { typeof(System.Double) };
        MethodInfo addDaysMethod = systemDateTimeType.GetMethod("AddDays", addDaysParamsTypes);
        object[] addDaysParams = new object[] { 10 };

        object newDateTimeInstance = addDaysMethod.Invoke(dateTimeInstance, addDaysParams);

        // Get the value of the property DateTime.Date and print it
        PropertyInfo datePropertyInfo = systemDateTimeType.GetProperty("Date");
        object datePropertyValue = datePropertyInfo.GetValue(newDateTimeInstance, null);
        Console.WriteLine("{0:dd.MM.yyyy}", datePropertyValue);
    }
}
