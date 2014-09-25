namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Linq;

    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);
        
        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);
    }
}
