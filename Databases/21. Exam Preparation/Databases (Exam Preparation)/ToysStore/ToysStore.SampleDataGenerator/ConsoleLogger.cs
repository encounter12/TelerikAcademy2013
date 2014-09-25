namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Linq;

    internal class ConsoleLogger: ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}
